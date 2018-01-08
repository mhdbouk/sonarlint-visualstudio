﻿/*
 * SonarQube Client
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

using SonarQube.Client.Messages;

namespace SonarQube.Client.Models
{
    public class SonarQubeProperty
    {
        public const string TestProjectRegexKey = "sonar.cs.msbuild.testProjectPattern";
        public const string TestProjectRegexDefaultValue = @"[^\\]*test[^\\]*$";

        public string Key { get; }
        public string Value { get; }

        public SonarQubeProperty(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static SonarQubeProperty FromResponse(PropertyResponse response)
        {
            return new SonarQubeProperty(response.Key, response.Value);
        }
    }
}