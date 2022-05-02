
// Author: Dashie


//
// THIS FILE IS PART OF THE CLOD.LIBRARY.  THIS FILE IS NOT MAINTAINED OR KEPT UP TO DATE.  HEAD OVER TO THE CLOD.LIBRARY WHICH FOR NOW CAN BE FOUND IN THE 'Study Helper\Library' FOLDER UNDER THE 'PersonalProjects' REPOSITORY!
//


using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Clod.Library
{
    public partial class PaintEventRegistrar
    {
        private static readonly Dictionary<Control, (List<bool> statuses, List<Action> runnables)> PaintRunnableCache = new();

        /// <summary>
        /// Validates the existence of a runnable by ID. Returns false when not found.
        /// </summary>
        public bool ValidateRunnableID(Control control, int runnableID)
        {
            if (PaintRunnableCache.ContainsKey(control))
            {
                if (PaintRunnableCache[control].runnables.Count > runnableID)
                {
                    if (runnableID >= 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Toggle the status of a runnable by ID. When enabled changes it to false. When disabled chanes it to true. Fails silently.
        /// </summary>
        public void TogglePaintEvent(Control control, int runnableID)
        {
            if (ValidateRunnableID(control, runnableID))
            {
                PaintRunnableCache[control].statuses[runnableID] = !PaintRunnableCache[control].statuses[runnableID];
            }
        }

        /// <summary>
        /// Remove a runnable by ID. Fails silently.
        /// </summary>
        public void RemovePaintEvent(Control control, int runnableID)
        {
            if (ValidateRunnableID(control, runnableID))
            {
                PaintRunnableCache[control].runnables.RemoveAt(runnableID);
                PaintRunnableCache[control].statuses.RemoveAt(runnableID);
            }
        }

        /// <summary>
        /// Add a paint event to execute the given runnable for the given control. Fails silently or throws an exception.
        /// </summary>
        public void AddPaintEvent(Control control, Action runnable)
        {
            if (control == null)
            {
                return;
            }

            else if (!PaintRunnableCache.ContainsKey(control))
            {
                control.Paint += (s, e) =>
                {
                    if (!PaintRunnableCache.ContainsKey(control))
                    {
                        return;
                    }

                    int id = 0;

                    foreach (var status in PaintRunnableCache[control].statuses)
                    {
                        if (status)
                        {
                            try
                            {
                                PaintRunnableCache[control].runnables[id]();
                            }

                            catch (Exception exception)
                            {
                                if (exception != Exceptions.PaintEventFailure)
                                {
                                    throw Exceptions.PaintEventExecutionFailure;
                                }

                                throw exception;
                            }
                        }

                        id += 1;
                    }
                };

                PaintRunnableCache.Add
                (
                    control,
                    (
                        new() { true },
                        new() { runnable }
                    )
                );
            }

            else
            {
                PaintRunnableCache[control].statuses.Add(true);
                PaintRunnableCache[control].runnables.Add(runnable);
            }
        }
    }
}