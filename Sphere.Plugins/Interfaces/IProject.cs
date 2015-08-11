using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for a Sphere game project.
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// Gets the full path of the project's root directory.
        /// </summary>
        string RootPath { get; }
        
        /// <summary>
        /// Gets or sets the name of the project (usually the game title).
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the project's author.
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets a short description of the game.
        /// </summary>
        string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the game's default horizontal resolution.
        /// </summary>
        int ScreenWidth { get; set; }

        /// <summary>
        /// Gets or sets the game's default vertical resolution.
        /// </summary>
        int ScreenHeight { get; set; }

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

        /// <summary>
        /// Builds the project so it can be run by Sphere.
        /// </summary>
        /// <returns>The fully qualified path of the generated game.sgm.</returns>
        string Build();
    }
}
