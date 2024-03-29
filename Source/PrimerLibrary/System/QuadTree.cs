﻿// <copyright file="Quadtree.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
//     Based on the code at: https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374 by Steven Lambert.
//     See also: https://gamedevelopment.tutsplus.com/tutorials/make-your-game-pop-with-particle-effects-and-quadtrees--gamedev-2138
//     See also: https://gamedevelopment.tutsplus.com/tutorials/collision-detection-using-the-separating-axis-theorem--gamedev-169
//     See also: http://www.mikechambers.com/blog/2011/03/21/javascript-quadtree-implementation/
//     See also: https://github.com/mikechambers/ExamplesByMesh/tree/master/JavaScript/QuadTree
// </remarks>

using MathematicsNotationLibrary;
using System.Collections.Generic;
using System.Drawing;

namespace PrimerLibrary;

/// <summary>
/// 
/// </summary>
public class Quadtree
{
    /// <summary>
    /// The maximum objects
    /// </summary>
    private const int MAX_OBJECTS = 10;

    /// <summary>
    /// The maximum levels
    /// </summary>
    private const int MAX_LEVELS = 5;

    /// <summary>
    /// The level
    /// </summary>
    private readonly int level;

    /// <summary>
    /// The objects
    /// </summary>
    private readonly List<IBoundable> objects;

    /// <summary>
    /// The bounds
    /// </summary>
    private RectangleF bounds;

    /// <summary>
    /// The nodes
    /// </summary>
    private readonly Quadtree?[] nodes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Quadtree"/> class.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="bounds">The bounds.</param>
    public Quadtree(int level, RectangleF bounds)
    {
        this.level = level;
        objects = new List<IBoundable>();
        this.bounds = bounds;
        nodes = new Quadtree[4];
    }

    /// <summary>
    /// Clears this instance of the <see cref="Quadtree"/>.
    /// </summary>
    public void Clear()
    {
        objects.Clear();

        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] is not null)
            {
                nodes[i]?.Clear();
                nodes[i] = null;
            }
        }
    }

    /// <summary>
    /// Splits this node instance into 4 sub-nodes.
    /// </summary>
    private void Split()
    {
        int subWidth = (int)(bounds.Width * 0.5f);
        int subHeight = (int)(bounds.Height * 0.5f);
        int x = (int)bounds.X;
        int y = (int)bounds.Y;

        nodes[0] = new Quadtree(level + 1, new Rectangle(x + subWidth, y, subWidth, subHeight));
        nodes[1] = new Quadtree(level + 1, new Rectangle(x, y, subWidth, subHeight));
        nodes[2] = new Quadtree(level + 1, new Rectangle(x, y + subHeight, subWidth, subHeight));
        nodes[3] = new Quadtree(level + 1, new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight));
    }

    /// <summary>
    /// Determine which node the object belongs to. -1 means
    /// object cannot completely fit within a child node and is part
    /// of the parent node
    /// </summary>
    /// <param name="rect">The p rect.</param>
    /// <returns></returns>
    private int GetIndex(IBoundable rect)
    {
        int index = -1;
        if (rect.Bounds is RectangleF b)
        {
            double verticalMidpoint = bounds.X + (bounds.Width * 0.5f);
            double horizontalMidpoint = bounds.Y + (bounds.Height * 0.5f);

            // Object can completely fit within the top quadrants
            bool topQuadrant = b.Y < horizontalMidpoint && b.Y + b.Height < horizontalMidpoint;

            // Object can completely fit within the bottom quadrants
            bool bottomQuadrant = b.Y > horizontalMidpoint;

            // Object can completely fit within the left quadrants
            if (b.X < verticalMidpoint && b.X + b.Width < verticalMidpoint)
            {
                if (topQuadrant)
                {
                    index = 1;
                }
                else if (bottomQuadrant)
                {
                    index = 2;
                }
            }
            // Object can completely fit within the right quadrants
            else if (b.X > verticalMidpoint)
            {
                if (topQuadrant)
                {
                    index = 0;
                }
                else if (bottomQuadrant)
                {
                    index = 3;
                }
            }
        }

        return index;
    }

    /// <summary>
    /// Insert the object into the quadtree. If the node
    /// exceeds the capacity, it will split and add all
    /// objects to their corresponding nodes.
    /// </summary>
    /// <param name="rect">The rect.</param>
    public void Insert(IBoundable rect)
    {
        if (nodes[0] is not null)
        {
            int index = GetIndex(rect);

            if (index != -1)
            {
                nodes[index]?.Insert(rect);

                return;
            }
        }

        objects.Add(rect);

        if (objects.Count > MAX_OBJECTS && level < MAX_LEVELS)
        {
            if (nodes[0] == null)
            {
                Split();
            }

            int i = 0;
            while (i < objects.Count)
            {
                int index = GetIndex(objects[i]);
                if (index != -1)
                {
                    nodes[index]?.Insert(objects[i]);
                    objects.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }

    /// <summary>
    /// Retrieves all objects that could collide with the given object.
    /// </summary>
    /// <param name="returnObjects">The return objects.</param>
    /// <param name="rect">The p rect.</param>
    /// <returns></returns>
    public List<IBoundable> Retrieve(List<IBoundable> returnObjects, IBoundable rect)
    {
        int index = GetIndex(rect);
        if (index != -1 && nodes[0] is not null)
        {
            nodes[index]?.Retrieve(returnObjects, rect);
        }

        // Wait. Is this right? This doesn't look right.
        returnObjects.AddRange(objects);

        return returnObjects;
    }
}
