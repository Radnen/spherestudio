﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the base interface for a compiler.
    /// </summary>
    public interface ICompiler : IPlugin
    {
        /// <summary>
        /// Builds a game distribution from a Sphere Studio project.
        /// </summary>
        /// <param name="project">The project to build.</param>
        /// <param name="outPath">The pathname of the directory where the distribution will be created.</param>
        /// <param name="con">An IConsole where compiler output will be sent.</param>
        /// <returns>'true' if compilation succeeded, false if not.</returns>
        Task<bool> Build(IProject project, string outPath, IConsole con);
    }

    /// <summary>
    /// Specifies the interface for a packaging compiler.
    /// </summary>
    public interface IPackager : ICompiler
    {
        /// <summary>
        /// Gets a list of package file filters, in the same format as used for
        /// SaveFileDialog.
        /// </summary>
        string SaveFileFilters { get; }

        /// <summary>
        /// Builds a game package from a Sphere Studio project.
        /// </summary>
        /// <param name="project">The project to build.</param>
        /// <param name="fileName">The pathname of the package. If this file exists, it will be overwritten.</param>
        /// <param name="con">An IConsole where compiler output will be sent.</param>
        /// <returns>'true' if packaging succeeded, false if not.</returns>
        Task<bool> Package(IProject project, string fileName, IConsole con);
    }
}