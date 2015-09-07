/**
 * Sphere Studio 2.0  (c) 2015 Spherical
 *
 * Sphere.js written by Bruce Pascoe
 * Build script to create a Sphere game distribution, with full
 * support for minisphere 1.7.
**/

RequireScript('link.js');

// ES6 polyfills
String.prototype.startsWith = function(searchString, position)
{
	position = position || 0;
	return this.indexOf(searchString, position) === position;
};

function prep(source)
{
	var mainScriptText =
		"function game()\n"
		+ "{"
		+ "\t\n"
		+ "}\n";

	Print("Creating Sphere subdirectories");
	source.mkdir('scripts');
	source.mkdir('animations');
	source.mkdir('fonts');
	source.mkdir('images');
	source.mkdir('maps');
	source.mkdir('sounds');
	source.mkdir('spritesets');
	source.mkdir('windowstyles');

	Print("Generating main.js")
	source.mainScript = "main.js";
	var file = new FileWriter(source.path + "main.js");
	file.write(mainScriptText);
	file.close();
}

function build(source, target)
{
	var debugMap = null;

	// Sphere file extensions
	// only files matching the extensions here will be copied into
	// the distribution.
	var extensions = [
		"rmp", "rss", "rts", "rws", "rfn",
		"js", "coffee", "glsl",
		"mp3", "ogg", "mid", "wav", "flac", "it", "s3m", "mod",
		"png", "jpg", "bmp", "pcx", "mng"
	];

	// copy over assets and build source map
	if (target.path != source.path) {
		Print("Copying files into distribution");
        Link(source.ls("*"))
            .where(function(filename) { return extensions.indexOf(filename.toLowerCase().split('.').reverse()[0]) != -1; })
            .where(function(filename) { return !filename.startsWith(source.buildPath); })
			.where(function(filename) { return filename != 'build.js'; })
			.each(function(filename)
        {
			source.cp(filename, target.path + filename);
			debugMap = debugMap || {};
			debugMap[filename] = filename;
		});
	}

	// save source map
	// the source map is used to map built assets to their corresponding
	// sources in the project.
	if (debugMap !== null) {
		Print("Writing source map");
		var file = new FileWriter(target.path + "sourcemap.json");
		file.write(JSON.stringify(debugMap, null, 2) + "\n");
		file.close();
	}

	// write game.sgm to target
	// unlike the Sphere 1.x stock editor, Sphere Studio manages projects using
	// its own .ssproj format so game.sgm must be generated at build time.
	Print("Generating game.sgm");
	var sgmFile = new FileWriter(target.path + "game.sgm");
	sgmFile.write("name=" + source.name + "\n");
	sgmFile.write("author=" + source.author + "\n");
	sgmFile.write("description=" + source.description + "\n");
	sgmFile.write("screen_width=" + source.screenWidth + "\n");
	sgmFile.write("screen_height=" + source.screenHeight + "\n");
	sgmFile.write("script=" + source.mainScript + "\n");
	sgmFile.close();
}

function clean(target)
{
	Print("Feeding PigGeta");
	target.rm("game.sgm");
}
