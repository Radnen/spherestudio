﻿using System.Collections.Generic;

namespace SphereStudio.Base
{
    /// <summary>
    /// Specifies the interface for a Sphere Studio project.
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// Gets the absolute path of the project's root directory.
        /// </summary>
        string RootPath { get; }

        /// <summary>
        /// Gets whether the project is currently in Sphere 1.x legacy mode.
        /// </summary>
        bool BackCompatible { get; }
        
        /// <summary>
        /// Gets or sets the path of the build directory. May be a
        /// relative path.
        /// </summary>
        string BuildPath { get; set; }

        /// <summary>
        /// Gets or sets the name of the project (usually the game title).
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the project's author.
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets a short summary/description of the game.
        /// </summary>
        string Summary { get; set; }
        
        /// <summary>
        /// Gets or sets the game's default horizontal resolution.
        /// </summary>
        int ScreenWidth { get; set; }

        /// <summary>
        /// Gets or sets the game's default vertical resolution.
        /// </summary>
        int ScreenHeight { get; set; }

        /// <summary>
        /// Gets the filename of the game's startup script, relative to
        /// 'scripts'.
        /// </summary>
        string MainScript { get; set; }

        /// <summary>
        /// Gets a dictionary of all breakpoints set for this project.
        /// </summary>
        /// <returns></returns>
        IReadOnlyDictionary<string, int[]> GetAllBreakpoints();
        
        /// <summary>
        /// Gets a list of breakpoints set for a specified file.
        /// </summary>
        /// <param name="scriptPath">The fully qualified path of the script to get breakpoints for.</param>
        /// <returns>An array of line numbers containing breakpoints.</returns>
        int[] GetBreakpoints(string scriptPath);

        /// <summary>
        /// Records breakpoints for a specified script file.
        /// </summary>
        /// <param name="scriptPath">The fully qualified path of the script with breakpoints.</param>
        /// <param name="lineNumbers">An array of line numbers with breakpoints.</param>
        void SetBreakpoints(string scriptPath, int[] lineNumbers);
    }
}
