using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for a Sphere game project.
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// Gets the fully qualified path of the project's root directory.
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
        /// Builds the project so it can be run by Sphere.
        /// </summary>
        void Build();
    }
}
