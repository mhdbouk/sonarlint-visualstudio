﻿/*
 * SonarLint for Visual Studio
 * Copyright (C) 2016-2018 SonarSource SA
 * mailto:info AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;

namespace SonarLint.VisualStudio.Integration
{
    /// <summary>
    /// Provides abstraction over the SCC file management. The files are queued up using <see cref="QueueFileWrite(string, Func{bool})"/>
    /// until <see cref="WriteQueuedFiles"/> which will call the SCC to check out the file and will run the queued up write operations.
    /// </summary>
    internal interface ISourceControlledFileSystem : IFileSystem
    {
        /// <summary>
        /// Queues a write operation for a file path. New or edit is determined internally at the time of this method execution.
        /// </summary>
        /// <param name="filePath">File path that want to write to</param>
        /// <param name="fileWriteOperation">The actual write operation, return false if failed</param>
        void QueueFileWrite(string filePath, Func<bool> fileWriteOperation);

        /// <summary>
        /// Returns whether the file exists on disk or in a queue to be written. <seealso cref="QueueFileWrite(string, Func{bool})"/>
        /// </summary>
        bool FileExistOrQueuedToBeWritten(string filePath);

        /// <summary>
        /// Checks out the file if the solution is under source control, and then executes all the queued file writes.  <seealso cref="QueueFileWrite(string, Func{bool})"/>
        /// </summary>
        /// <returns>Whether was able to checkout (if applicable) and write to all the files</returns>
        bool WriteQueuedFiles();
    }
}
