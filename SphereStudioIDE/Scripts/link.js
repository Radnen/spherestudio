/**
* Script: Link.js
* Written by: Andrew Helenius
* Updated: May/11/2015
* Version: 0.3.0
* Desc: Link.js is a very fast general-purpose functional programming library.
		Still somewhat experimental, and still under construction.
**/

var Link = (function(undefined) {
	"use strict";
	
	var _slice = [].slice;
	
	function _IndexOf(array, elem) {
		for (var i = 0, l = array.length; i < l; ++i) {
			if (array[i] === elem) return i;
		}
		return -1;
	};
	
	function _IsArray(a) {
		return Object.prototype.toString.call(a) === "[object Array]";
	}
	
	/** Point Layer **/

	function WherePoint(fn) {
		this.next = null;
		this.env  = null;
		this.func = fn;
	}
	
	WherePoint.prototype.exec = function(item, i) {
		if (this.func(item)) this.next.exec(item, i);
	}
	
	WherePoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			f = this.func, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { if (f(a[i])) n.exec(a[i], i); i++; }
		else
			while (i < l) { if (f(a[i])) n.exec(a[i], i); i++; }
	}

	function HasPoint(prop, item) {
		this.next = null;
		this.env  = null;
		this.item = item;
		this.prop = prop;
	}
	
	HasPoint.prototype.exec = function(item, i) {
		if (_IndexOf(item[this.prop], this.item) >= 0) this.next.exec(item, i);
	}

	function HasFuncPoint(prop, func) {
		this.next = null;
		this.env  = null;
		this.func = func;
		this.prop = prop;
	}
	
	HasFuncPoint.prototype.exec = function(item, i) {
		var array = item[this.prop];
		for (var i = 0, l = array.length; i < l; ++i) {
			if (this.func(array[i], i)) { this.next.exec(item, i); break; }
		}
	}
	
	function RejectPoint(fn) {
		this.next = null;
		this.env  = null;
		this.func = fn;
	}
	
	RejectPoint.prototype.exec = function(item, i) {
		if (!this.func(item, i)) this.next.exec(item, i);
	}
	
	RejectPoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env, f = this.func, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { if (!f(a[i], i)) n.exec(a[i], i); i++; }
		else
			while (i < l) { if (!f(a[i], i)) n.exec(a[i], i); i++; }
	}
		
	function FilterByPoint(key, values) {
		this.next = null;
		this.env  = null;
		this.key  = key;
		this.vals = values;
	}
	
	FilterByPoint.prototype.exec = function(item, i) {
		if (_IndexOf(this.vals, item[this.key])) this.next.exec(item, i);
	}
	
	FilterByPoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			k = this.key, v = this.vals, n = this.next;
		if (e.take)
			while (i < l && !e.stop) {
				if (_IndexOf(v, a[i][k]) >= 0) n.exec(a[i], i);
				i++;
			}
		else
			while (i < l) {
				if (_IndexOf(v, a[i][k]) >= 0) n.exec(a[i], i);
				i++;
			}
	}

	function FilterByOnePoint(key, val) {
		this.next = null;
		this.env  = null;
		this.key  = key;
		this.val  = val;
	}
	
	FilterByOnePoint.prototype.exec = function(item, i) {
		if (item[this.key] === this.val) this.next.exec(item, i);
	}
	
	FilterByOnePoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			v = this.val, k = this.key, n = this.next;
		if (e.take)
			while (!e.stop && i < l) { var p = a[i]; if (v === p[k]) n.exec(p, i); i++; }
		else
			while (i < l) { var p = a[i]; if (v === p[k]) n.exec(p, i); i++; }
	}
	
	function PluckPoint(prop) {
		this.next = null;
		this.env  = null;
		this.prop = prop;
	}
	
	PluckPoint.prototype.exec = function(item, i) {
		this.next.exec(item[this.prop], i);
	}
	
	PluckPoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env, k = this.prop, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { n.exec(a[i][k], i); i++; }
		else
			while (i < l) { n.exec(a[i][k], i); i++; }
	}
	
	function SelectPoint(args) {
		this.next = null;
		this.env  = null;
		this.args = args;
	}
	
	SelectPoint.prototype.exec = function(item, i) {
		var obj = { }, i = this.args.length;
		while (i--) {
			obj[this.args[i]] = item[this.args[i]];
		}
		this.next.exec(obj, i);
	}
	
	function ArrayJoinPoint(delim) { // end point
		this.next  = null;
		this.env   = null;
		this.delim = delim || "";
		this.text  = "";
	}
	
	ArrayJoinPoint.prototype.exec = function(item, i) {
		this.text += item + this.delim;
	}
	
	function JoinPoint(other, cond) {
		this.next  = null;
		this.env   = null;
		this.other = other;
		this.cond  = cond;
	}
	
	JoinPoint.prototype.exec = function(item, i) {
		for (var i = 0, l = this.other.length; i < l; ++i) {
			var other = this.other[i];
			if (this.cond(item, other)) {
				var obj = { };
				for (var j in other) obj[j] = other[j];
				for (var j in item) obj[j] = item[j];
				this.next.exec(obj, i);
			}
		}
	}

	function MapPoint(fn) {
		this.next = null;
		this.env  = null;
		this.func = fn;
	}
	
	MapPoint.prototype.exec = function(item, i) {
		this.next.exec(this.func(item, i), i);
	}
	
	MapPoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			f = this.func, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { n.exec(f(a[i], i), i); i++; }
		else
			while (i < l) { n.exec(f(a[i], i), i); i++; }
	}

	function Map2Point(fn1, fn2) {
		this.next = null;
		this.env  = null;
		this.map1 = fn1;
		this.map2 = fn2;
	}
	
	Map2Point.prototype.exec = function(item, i) {
		this.next.exec(this.map2(this.map1(item, i), i));
	}
	
	Map2Point.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			f1 = this.map1, f2 = this.map2, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { n.exec(f2(f1(a[i], i), i)); i++; }
		else
			while (i < l) { n.exec(f2(f1(a[i], i), i)); i++; }
	}

	function WhereMapPoint(fn1, fn2) {
		this.next  = null;
		this.env   = null;
		this.where = fn1;
		this.map   = fn2;
	}
	
	WhereMapPoint.prototype.exec = function(item, i) {
		if (this.where(item, i)) this.next.exec(this.map(item, i), i);
	}

	function MapWherePoint(fn1, fn2) {
		this.next  = null;
		this.env   = null;
		this.map   = fn1;
		this.where = fn2;
	}
	
	MapWherePoint.prototype.exec = function(item, i) {
		var v = this.map(item, i);
		if (this.where(v, i)) this.next.exec(v, i);
	}

	MapWherePoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			f1 = this.where, f2 = this.map, n = this.next;
		if (e.take)
			while (i < l && !e.stop) {
				var v = f2(a[i], i); if (f1(v, i)) n.exec(v, i); i++;
			}
		else
			while (i < l) {
				var v = f2(a[i], i); if (f1(v, i)) n.exec(v, i); i++;
			}
	}

	function Where2Point(fn1, fn2) {
		this.next   = null;
		this.env    = null;
		this.where1 = fn1;
		this.where2 = fn2;
	}
	
	Where2Point.prototype.exec = function(item, i) {
		if (this.where1(item, i) && this.where2(item, i)) this.next.exec(item, i);
	}
	
	Where2Point.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			f1 = this.where1, f2 = this.where2, n = this.next;
		if (e.take)
			while (i < l && !e.stop) {
				var v = a[i];
				if (f1(v, i) && f2(v, i)) n.exec(v, i); i++;
			}
		else
			while (i < l) {
				var v = a[i];
				if (f1(v, i) && f2(v, i)) n.exec(v, i); i++;
			}
		return i;
	}

	function ZipPoint(array) {
		this.next = null;
		this.env  = null;
		this.i    = 0;
	}

	ZipPoint.prototype.exec = function(item, i) { this.next.exec([item, array[this.i++]], i); }
	
	ZipPoint.prototype.reset = function() { this.i = 0; }
	
	function RemovePoint() { // endpoint
		this.items = [];
	}
	
	RemovePoint.prototype.exec = function(item, i) {
		this.items.push(i);
	}
	
	function GroupByPoint(groupFn, container) { // end point
		this.next  = null;
		this.env   = null;
		this.func  = groupFn;
		this.group = container;
		this.isObj = !_IsArray(container);
		this.indices = [];
	}
	
	GroupByPoint.prototype.exec = function(item, i) {
		var value = this.func(item, i);
		if (this.isObj) {
			if (!this.group[value]) this.group[value] = [item];
			else this.group[value].push(item);
		}
		else {
			var index = _IndexOf(this.indices, value);
			if (index < 0) {
				this.indices.push(value);
				this.group.push([item]);
			}
			else this.group[index].push(item);
		}
	}

	function SlicePoint(a, b) {
		this.next = null;
		this.env  = null;
		this.i    = 0;
		this.a    = a;
		this.b    = b;
	}

	SlicePoint.prototype.exec = function(item, i) {
		if (this.i >= this.b) { this.env.stop = true; this.i = 0; return; }
		else if (this.i >= this.a) this.next.exec(item, i);
		this.i++;
	}
	
	function FirstFuncPoint(fn) {
		this.next = null;
		this.env  = null;
		this.func = fn;
	}
	
	FirstFuncPoint.prototype.exec = function(item, i) {
		if (this.func(item, i)) { this.env.stop = true; this.next.exec(item, i); }
	}

	function FirstPoint() {
		this.next = null;
		this.env  = null;
	}
	
	FirstPoint.prototype.exec = function(item, i) {
		this.env.stop = true;
		this.next.exec(item, i);
	}
	
	function FirstCountPoint(num) {
		this.next = null;
		this.env  = null;
		this.num  = num;
		this.i    = 0;
	}
	
	FirstCountPoint.prototype.exec = function(item, i) {
		if (++this.i == this.num) this.env.stop = true;
		this.next.exec(item, i);
	}
	
	function UpdatePoint(prop, value) { // end point
		this.next = null;
		this.env  = null;
		this.prop = prop;
		this.val  = value;
	}
	
	UpdatePoint.prototype.exec = function(item, i) {
		item[this.prop] = this.val;
	}
	
	function IsPoint(inst) {
		this.next = null;
		this.env  = null;
		this.inst = inst;
	}
	
	IsPoint.prototype.exec = function(item, i) { if (item instanceof this.inst) this.next.exec(item, i); }
	
	IsPoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			ins = this.inst, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { if (a[i] instanceof ins) n.exec(a[i], i); i++; }
		else
			while (i < l) { if (a[i] instanceof ins) n.exec(a[i], i); i++; }
	}
	
	function TypePoint(type) {
		this.next = null;
		this.env  = null;
		this.type = type;
	}
	
	TypePoint.prototype.exec = function(item, i) { if (typeof item == this.type) this.next.exec(item, i); }
	
	TypePoint.prototype.run = function(a) {
		var i = 0, l = a.length, e = this.env,
			t = this.type, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { if (typeof a[i] == t) n.exec(a[i], i); i++; }
		else
			while (i < l) { if (typeof a[i] == t) n.exec(a[i], i); i++; }
	}
	
	function SkipPoint(n) {
		this.next = null;
		this.env  = null;
		this.n    = n;
		this.skip = 0;
	}
	
	SkipPoint.prototype.exec = function(item, i) {
		if (this.skip == this.n) { this.next.exec(item, i); }
		else this.skip++;
	}
	
	SkipPoint.prototype.reset = function() { this.skip = 0; }

	function GetPoint(n) {
		this.next = null;
		this.env  = null;
		this.c    = 0;
		this.n    = n;
		this.obj  = null;
	}
	
	GetPoint.prototype.exec = function(item, i) {
		if (this.c == this.n) {
			this.env.stop = true;
			this.obj = item;
		} this.c++;
	}

	function ContainsFuncPoint(fn) { // end point
		this.next = null;
		this.env  = null;
		this.func = fn;
		this.pass = false;
	}
	
	ContainsFuncPoint.prototype.exec = function(item, i) {
		if (this.func(item, i)) this.pass = this.env.stop = true;
	}
	
	function ContainsPoint(o) { // end point
		this.next = null;
		this.env  = null;
		this.obj  = o;
		this.pass = false;
	}
	
	ContainsPoint.prototype.exec = function(item, i) {
		if (item === this.obj) this.pass = this.env.stop = true;
	}
	
	ContainsPoint.prototype.run = function(a) {
		var i = 0, l = a.length, t = this.obj;
		while (i < l) { if (a[i++] === t) { this.pass = true; break; } }
	}
	
	function ContainsAnyPoint(array) { // end point
		this.next = null;
		this.env  = null;
		this.arr  = array;
		this.pass = false;
	}
	
	ContainsAnyPoint.prototype.exec = function(item, i) {
		if (_IndexOf(this.arr, item) >= 0) this.pass = this.env.stop = true;
	}
	
	ContainsAnyPoint.prototype.run = function(a) {
		var i = 0, l = a.length, arr = this.arr;
		while (i < l) {
			if (_IndexOf(this.arr, a[i++]) >= 0) { this.pass = true; break; }
		}
	}
	
	function EveryPoint(func) { // end point
		this.next = null;
		this.env  = null;
		this.pass = true;
		this.func = func;
	}

	EveryPoint.prototype.exec = function(item, i) {
		if (!this.func(item, i)) { this.pass = false; this.env.stop = true; }
	}
	
	function NonePoint(func) { // end point
		this.next = null;
		this.env  = null;
		this.pass = true;
		this.func = func;
	}
	
	NonePoint.prototype.exec = function(item, i) {
		if (this.func(item, i)) { this.pass = false; this.env.stop = true; }
	}

	function IndexOfPoint(v) { // end point
		this.next  = null;
		this.env   = null;
		this.value = v;
		this.index = 0;
		this.found = false;
	}
	
	IndexOfPoint.prototype.exec = function(item, i) {
		if (item == this.value) this.env.stop = this.found = true;
		else this.index++;
	}

	IndexOfPoint.prototype.run = function(a) {
		var i = 0, l = a.length, v = this.value, n = this.next;
		while (i < l) { if (a[i] == v) { this.index = i; this.found = true; break; } else i++; }
	}
	
	function IndexOfFuncPoint(fn) {
		this.next  = null;
		this.env   = null;
		this.func  = fn;
		this.index = 0;
		this.found = false;
	}
	
	IndexOfFuncPoint.prototype.exec = function(item, i) {
		if (this.func(item, i)) this.env.stop = this.found = true;
		else this.index++;
	}

	IndexOfFuncPoint.prototype.run = function(a) {
		var i = 0, l = a.length, fn = this.func, n = this.next;
		while (i < l) { if (fn(a[i], i)) { this.index = i; this.found = true; break; } else i++; }
	}

	function IndexOfPropPoint(p, v) { // end point
		this.next  = null;
		this.env   = null;
		this.prop  = p;
		this.value = v;
		this.index = 0;
	}
	
	IndexOfPropPoint.prototype.exec = function(item, i) {
		if (item[this.prop] == this.value) this.env.stop = this.found = true;
		else this.index++;
	}
	
	IndexOfPropPoint.prototype.run = function(a) {
		var i = 0, l = a.length, p = this.prop, v = this.value, n = this.next;
		while (i < l) { if (a[i][p] == v) { this.index = i; this.found = true; break; } else i++; }
	}

	function EachPoint(fn) { this.exec = fn; }
	
	function ExecutePoint(fn) {
		this.next = null;
		this.env  = null;
		this.func = fn;
	}
	
	ExecutePoint.prototype.exec = function(item, i) {
		this.func(item, i);
		this.next.exec(item, i);
	}
	
	function AveragePoint() { // end point
		this.env   = null;
		this.next  = null;
		this.total = 0;
		this.items = 0;
	}
	
	AveragePoint.prototype.exec = function(item, i) {
		this.total += item;
		this.items++;
	}

	function AveragePropPoint(prop) { // end point
		this.env   = null;
		this.next  = null;
		this.prop  = prop;
		this.total = 0;
		this.items = 0;
	}
	
	AveragePropPoint.prototype.exec = function(item, i) {
		this.total += item[this.prop];
		this.items++;
	}
	
	function AverageFuncPoint(func) { // end point
		this.env   = null;
		this.next  = null;
		this.prop  = func;
		this.total = 0;
		this.items = 0;
	}

	AverageFuncPoint.prototype.exec = function(item, i) {
		this.total += this.func(item, i);
		this.items++;
	}
	
	function SumPoint() { // end point
		this.env   = null;
		this.next  = null;
		this.total = 0;
	}
	
	SumPoint.prototype.exec = function(item, i) {
		this.total += item;
	}
	
	function SumPropPoint(prop) { // end point
		this.env   = null;
		this.next  = null;
		this.prop  = prop;
		this.total = 0;
	}
	
	SumPropPoint.prototype.exec = function(item, i) {
		this.total += item[this.prop];
	}
	
	function SumFuncPoint(func) { // end point
		this.env   = null;
		this.next  = null;
		this.func  = func;
		this.total = 0;
	}

	SumFuncPoint.prototype.exec = function(item, i) {
		this.total += this.func(item, i);
	}
	
	function MinPoint(rank) { // end point
		this.next  = null;
		this.env   = null;
		this.func  = rank;
		this.value = Number.MAX_VALUE;
		this.obj   = undefined;
	}
	
	MinPoint.prototype.exec = function(item, i) {
		var v = this.func(item, i);
		if (v < this.value) { this.value = v; this.obj = item; }
	}

	function MaxPoint(rank) { // end point
		this.next  = null;
		this.env   = null;
		this.func  = rank;
		this.value = Number.MIN_VALUE;
		this.obj   = undefined;
	}

	MaxPoint.prototype.exec = function(item, i) {
		var v = this.func(item, i);
		if (v > this.value) { this.value = v; this.obj = item; }
	}
	
	function InvokePoint(method) { // end point
		this.next = null;
		this.env  = null;
		this.name = method;
	}
	
	InvokePoint.prototype.exec = function(item, i) { item[this.name](); }
	
	InvokePoint.prototype.run = function(a) {
		var i = 0, l = a.length, n = this.name;
		while(i < l) { a[i++][n](); }
	}
	
	function InvokeArgsPoint(method, args) { // end point
		this.next = null;
		this.env  = null;
		this.name = method;
		this.args = args;
	}
	
	InvokeArgsPoint.prototype.exec = function(item, i) { item[this.name].apply(item, this.args); }
	
	InvokeArgsPoint.prototype.run = function(a) {
		var i = 0, l = a.length, n = this.name, args = this.args;
		while(i < l) { var m = a[i++]; m[n].apply(m, args); }
	}
	
	function ExpandPoint() {
		this.next = null;
		this.env  = null;
	}
	
	ExpandPoint.prototype.exec = function(item, i) {
		var i = 0, l = item.length, e = this.env, n = this.next;
		if (e.take)
			while (i < l && !e.stop) { n.exec(item[i], i); i++; }
		else
			while (i < l) { n.exec(item[i], i); i++; }
	}
	
	function ExpandPropPoint(prop) {
		this.next = null;
		this.env  = null;
		this.prop = prop;
	}
	
	ExpandPropPoint.prototype.exec = function(item, i) {
		var i = 0, a = item[this.prop], l = a.length;
		while (i < l) { this.next.exec(a[i], i); i++; }
	}

	function TakePoint(size) {
		this.next = null;
		this.env  = null;
		this.i    = 0;
		this.num  = size;
	}
	
	TakePoint.prototype.exec = function(item, i) {
		this.next.exec(item, i);
		if (++this.i == this.num) { this.env.stop = true; this.i = 0; }
	}

	function CountPoint(func) { // end point
		this.next   = null;
		this.env    = null;
		this.func   = func;
		this.counts = { num: 0, total: 0 };
	}
	
	CountPoint.prototype.exec = function(item, i) {
		this.counts.total++;
		if (this.func(item, i)) this.counts.num++;
	}

	// true unique-ness testing is a near-impossible or made too damn slow in JS, so an approximation will do:
	function UniqPoint(test) {
		this.next = null;
		this.env  = null;
		this.test = test || false;
		this.set  = []; // for primitives
		this.ref  = []; // for object references
	}
	
	UniqPoint.prototype.exec = function(item, i) {
		if (typeof item == "object") {
			var i = this.ref.length;
			if (this.test)
				while (i--) { if (this.test(item, this.ref[i])) return; }
			else
				while (i--) { if (this.ref[i] == item) return; }
			this.ref.push(item);
			this.next.exec(item, i);
		}
		else if (!this.set[item]) { this.set[item] = true; this.next.exec(item, i); }
	}
	
	UniqPoint.prototype.reset = function() {
		this.set.length = 0;
		this.ref.length = 0;
	}

	function LengthPoint() { // end point
		this.next = null;
		this.env  = null;
		this.num  = 0;
	}
	
	LengthPoint.prototype.exec = function(item, i) { this.num++; }
	
	function RecursePoint(prop) {
		this.next = null;
		this.env  = null;
		this.prop = prop;
	}
	
	RecursePoint.prototype.exec = function(item) {
		if (item && this.prop in item) {
			var a = item[this.prop], l = a.length;
			for (var i = 0; i < l; ++i) { this.next.exec(a[i]); this.exec(a[i]); }
		}
	}

	function ReducePoint(fn, m) { // end point
		this.next = null;
		this.env  = null;
		this.func = fn;
		this.memo = m;
	}
	
	ReducePoint.prototype.exec = function(item, i) {
		if (this.memo === undefined)
			this.memo = item;
		else
			this.memo = this.func(this.memo, item, i);
	}

	function AllPoint(array) { // end point
		this.next  = null;
		this.env   = null;
		this.array = [];
	}
	
	AllPoint.prototype.exec = function(item, i) { this.array[this.array.length] = item; }
	
	AllPoint.prototype.run = function(a) {
		var i = a.length, b = this.array;
		while (i--) b[i] = a[i];
	}
	
	function CoalescePropPoint(prop) { // end point
		this.env  = null;
		this.prop = prop;
	}
	
	CoalescePropPoint.prototype.exec = function(item, i) {
		this.env.target[i][this.prop] = item;
	}
	
	function CoalescePoint() { // end point
		this.env = null;
	}
	
	CoalescePoint.prototype.exec = function(item, i) {
		this.env.target[i] = item;
	}
	
	function UnpluckPoint(prop) {
		this.env  = null;
		this.prop = prop;
		this.next = null;
	}
	
	UnpluckPoint.prototype.exec = function(item, i) {
		this.env.target[i][this.prop] = item;
		this.next.exec(this.env.target[i], i);
	}
	
	function SplitPoint(delim) {
		this.env  = null;
		this.next = null;
		this.del  = delim;
		this.word = "";
	}
	
	SplitPoint.prototype.exec = function(item, i) {
		if (item == this.del || item == "\0") {
			this.next.exec(this.word, i);
			this.word = "";
		}
		else this.word += item;
	}
	
	/** Functional Layer **/

	function PushPoint(point) {
		point.env = this.env;
		var last  = this.points.length - 1;
		if (last >= 0) this.points[last].next = point;
		this.points.push(point);
	}
	
	function ReplaceEnd(point) {
		point.env = this.env;
		var last  = this.points.length - 1;
		this.points[last] = point;
		if (last > 0) this.points[last - 1].next = point;
	}
	
	function Each(fn) {
		this.run(new EachPoint(fn));
	}
	
	function Execute(fn) {
		this.pushPoint(new ExecutePoint(fn));
		return this;
	}
		
	function Run(point) {
		this.env.stop = false;
		this.env.skip = 0;
		
		if (point) this.pushPoint(point);
		
		// reset the points that store data between runs
		var i = this.points.length;
		while (i--) {
			var p = this.points[i];
			if (p.reset) p.reset();
		}

		// kick-start points that have a runner tied to them:
		var start = this.points[0];
		if (start.run) { start.run(this.target); }
		else {
			var a = this.target, l = a.length, i = 0, e = this.env;
			if (e.take)
				while (i < l && !e.stop) start.exec(a[i], i++);
			else
				while (i < l) start.exec(a[i], i++);
		}
		this.points.length--;
	}
	
	function ToArray() {
		var point = new AllPoint();
		this.run(point);
		return point.array;
	}
	
	function Count(fn) {
		var point = new CountPoint(fn);
		this.run(point);
		return point.counts;
	}
	
	function Length() {
		var point = new LengthPoint();
		this.run(point);
		return point.num;
	}
	
	function Has(prop, value) {
		if (typeof value === "function")
			this.pushPoint(new HasFuncPoint(prop, value));
		else
			this.pushPoint(new HasPoint(prop, value));
		return this;
	}
	
	function Contains(o) {
		this.env.take = true;
		var point;
		if (typeof o == "function")
			point = new ContainsFuncPoint(o);
		else if (_IsArray(o))
			point = new ContainsAnyPoint(o);
		else
			point = new ContainsPoint(o);
		this.run(point);
		return point.pass;
	}
	
	function Update(prop, value) {
		this.run(new UpdatePoint(prop, value));
	}
	
	function IndexOf(p, v) {
		this.env.take = true;
		var point;
		if (typeof p == 'function') {
			point = new IndexOfFuncPoint(p);
		}
		else if (v !== undefined)
			point = new IndexOfPropPoint(p, v);
		else
			point = new IndexOfPoint(p);
		this.run(point);
		return point.found ? point.index : -1;
	}
	
	function Pluck(prop) {
		this.pushPoint(new PluckPoint(prop));
		return this;
	}
	
	function Unpluck(prop) {
		this.pushPoint(new UnpluckPoint(prop));
		return this;
	}
	
	function GroupBy(fn, asArray) {
		var point = new GroupByPoint(fn, asArray ? [] : {});
		this.run(point);
		return point.group;
	}
	
	function FilterBy(key, a) {
		if (_IsArray(a))
			this.pushPoint(new FilterByPoint(key, a));
		else
			this.pushPoint(new FilterByOnePoint(key, a));
		return this;
	}
	
	function Every(fn) {
		this.env.take = true;
		var point = new EveryPoint(fn);
		this.run(point);
		return point.pass;
	}
	
	function None(fn) {
		this.env.take = true;
		var point = new NonePoint(fn);
		this.run(point);
		return point.pass;
	}
	
	function Expand(prop) {
		if (prop)
			this.pushPoint(new ExpandPropPoint(prop));
		else
			this.pushPoint(new ExpandPoint());
		return this;
	}
	
	function Reduce(agg, memo) {
		var point = new ReducePoint(agg, memo);
		this.run(point);
		return point.memo;
	}
		
	function Sample(num) {
		if (!num) num = 1;
		this.env.take = true;
		this.pushPoint(new SamplePoint(num));
		return this;
	}
		
	function Where(propOrFn, value) {
		if (value !== undefined) { return this.filterBy(propOrFn, value); }
		var last = this.points[this.points.length - 1];
		if (last instanceof WherePoint)
			this.replaceEnd(new Where2Point(last.func, propOrFn));
		else if (last instanceof MapPoint)
			this.replaceEnd(new MapWherePoint(last.func, propOrFn));
		else
			this.pushPoint(new WherePoint(propOrFn));
		return this;
	}
	
	function Reject(func) {
		this.pushPoint(new RejectPoint(func));
		return this;
	}
	
	function Map(func) {
		var last = this.points[this.points.length - 1];
		if (last instanceof WherePoint)
			this.replaceEnd(new WhereMapPoint(last.func, func));
		else if (last instanceof MapPoint)
			this.replaceEnd(new Map2Point(last.func, func));
		else
			this.pushPoint(new MapPoint(func));
		return this;
	}
	
	function Concat(array) {
		if (array instanceof Chain) array = array.toArray();
		return Link(this.toArray(), array);
	}
	
	function Average(obj) {
		var point = null;
		if (typeof obj == "function")
			point = new AverageFuncPoint(obj);
		else if (typeof obj == "string")
			point = new AveragePropPoint(obj);
		else
			point = new AveragePoint();
		this.run(point);
		if (point.items == 0) return 0;
		return point.total / point.items;
	}

	function Sum(obj) {
		var point = null;
		if (typeof obj == "function")
			point = new SumFuncPoint(obj);
		else if (typeof obj == "string")
			point = new SumPropPoint(obj);
		else
			point = new SumPoint();
		this.run(point);
		return point.total;
	}
	
	function Max(rank) {
		var point = new MaxPoint(rank);
		this.run(point);
		return point.obj;
	}
	
	function Min(rank) {
		var point = new MinPoint(rank);
		this.run(point);
		return point.obj;
	}
	
	function Invoke(name, args) {
		if (args === undefined)
			this.run(new InvokePoint(name));
		else
			this.run(new InvokeArgsPoint(name, _slice.call(arguments, 1)));
	}
	
	function Skip(num) {
		this.pushPoint(new SkipPoint(num));
		return this;
	}
	
	function Is(inst) {
		this.pushPoint(new IsPoint(inst));
		return this;
	}
	
	function Type(type) {
		this.pushPoint(new TypePoint(type));
		return this;
	}
	
	function First(o) {
		this.env.take = true;
		var point;
		if (typeof o == "function")
			point = new FirstFuncPoint(o);
		else if (typeof o == "number")
			return o < 0 ? undefined : this.take(o);
		else
			point = new FirstPoint();
		this.pushPoint(point);
		var a = this.toArray();
		return a.length > 0 ? a[0] : undefined;
	}
	
	function Zip(array) {
		if (array instanceof Chain) array = array.toArray();
		this.pushPoint(new ZipPoint(array));
		return this;
	}
	
	function Remove() {
		var point = new RemovePoint();
		this.run(point);
		var a = point.items, i = a.length;
		while (i--) { this.target.splice(a[i], 1); }
	}
	
	function Slice(a, b) {
		if (a == 0) return this;
		this.env.take = true;
		if (!b) b = Number.MAX_VALUE;
		this.pushPoint(new SlicePoint(a, b));
		return this;
	}
	
	function Last(count) {
		var a = this.toArray();
		if (!count) count = 1;
		return a.splice(a.length - count);
	}
	
	function Sample(times) {
		if (!times) times = 1;
		var a = this.toArray();
		times = Math.min(times, a.length);
		var samples = [];
		while (times--) {
			var i = Math.floor(Math.random() * a.length);
			samples.push(a[i]);
			a.splice(i, 1);
		}
		return samples;
	}

	function Random(times) {
		if (!times) times = 1;
		var a = this.toArray();
		var samples = [];
		while (times--) {
			var i = Math.floor(Math.random() * a.length);
			samples.push(a[i]);
		}
		return samples;
	}
	
	function Select() {
		this.pushPoint(new SelectPoint([].slice.apply(arguments)));
		return this;
	}
	
	function Coalesce(prop) {
		if (prop === undefined) { this.run(new CoalescePoint()); }
		else { this.run(new CoalescePropPoint(prop)); }
	}
	
	function Split(delim) {
		this.target += "\0";
		this.pushPoint(new SplitPoint(delim));
		return this;
	}
	
	function Join(obj, func) {
		if (!func) {
			var point = new ArrayJoinPoint(obj);
			this.run(point);
			return point.text;
		}
		else {
			this.pushPoint(new JoinPoint(obj, func));
			return this;
		}
	}
	
	function Take(n) {
		this.env.take = true;
		this.pushPoint(new TakePoint(n));
		return this;
	}
	
	function Get(num) {
		this.env.take = true;
		var point = new GetPoint(num);
		this.run(point);
		return point.obj;
	}
	
	function Uniq(test) {
		this.pushPoint(new UniqPoint(test));
		return this;
	}
	
	function Sort(f) {
		var v = this.toArray();
		if (f) v.sort(f); else v.sort();
		return v;
	}
	
	function Shuffle() {
		var v = this.toArray();
		for (var i = v.length - 1; i > 0; --i) {
			var j = Math.floor(Math.random() * (i + 1));
			var tmp = v[i];
			v[i] = v[j];
			v[j] = tmp;
		}
		return v;
	}
	
	function Recurse(prop) {
		this.pushPoint(new RecursePoint(prop));
		return this;
	}
	
	function Swap(a, b) {
		var c = this.target[b];
		this.target[b] = this.target[a];
		this.target[a] = c;
	}
	
	function Retarget(a) {
		this.env.target = a;
		this.target = a;
		return this;
	}
	
	/** Interface Layer **/
	
	function Chain(array, dim) {
		this.target = array || [];
		this.env    = { take: false, stop: false, target: this.target };
		this.points = [];
	}
	
	Chain.prototype = {
		pushPoint : PushPoint,
		replaceEnd: ReplaceEnd,
		run       : Run,
		retarget  : Retarget,

		accept    : Where,
		average   : Average,
		coalesce  : Coalesce,
		concat    : Concat,
		contains  : Contains,
		count     : Count,
		drop      : Skip,
		each      : Each,
		every     : Every,
		execute   : Execute,
		exists    : Contains,
		expand    : Expand,
		expandInto: Expand,
		filter    : Where,
		filterBy  : FilterBy,
		filterOut : Reject,
		first     : First,
		fuse      : Coalesce,
		get       : Get,
		groupBy   : GroupBy,
		has       : Has,
		indexOf   : IndexOf,
		invoke    : Invoke,
		is        : Is,
		join      : Join,
		last      : Last,
		length    : Length,
		map       : Map,
		max       : Max,
		min       : Min,
		none      : None,
		pluck     : Pluck,
		random    : Random,
		recurse   : Recurse,
		reduce    : Reduce,
		reject    : Reject,
		remove    : Remove,
		sample    : Sample,
		select    : Select,
		shuffle   : Shuffle,
		size      : Length,
		skip      : Skip,
		slice     : Slice,
		some      : Contains,
		sort      : Sort,
		split     : Split,
		sum       : Sum,
		swap      : Swap,
		take      : Take,
		toArray   : ToArray,
		type      : Type,
		typeOf    : Type,
		uniq      : Uniq,
		unique    : Uniq,
		unpluck   : Unpluck,
		unroll    : Expand,
		update    : Update,
		where     : Where,
		whereBy   : FilterBy,
		zip       : Zip,
	}
		
	function Link(arr, test) {
		if (!test)
			return new Chain(arr);
		else {
			var a = _slice.call(arguments, 0);
			return (new Chain(a)).unroll();
		}
	}
	
	Link.create = function() {
		var args = _slice.call(arguments, 0),
			stop = args.length - 1,
			v    = args[stop],
			isFn = (typeof v == "function"),
			indices = [];
		
		function CreateArray(n) {
			if (n == stop) return (isFn) ? v.apply(this, indices) : v;
			var a = [], l = args[n], n = n + 1;
			for (var i = 0; i < l; ++i) {
				indices[n - 1] = i;
				a[i] = CreateArray(n);
			}
			return a;
		}
		
		return CreateArray(0);
	}
	
	Link.range = function(num) {
		var a = [];
		while (num--) { a[num] = num; }
		return a;
	}
	
	Link.alias = function(from, to) {
		Chain.prototype[to] = Chain.prototype[from];
		return this;
	}
	
	return Link;
})();
