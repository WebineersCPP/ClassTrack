using ClassTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrack.Services
{
    public class GETGEModule
    {
        public Module ge = new Module()
        {
            Title = "General Education Requirements: 68 units",
            Units = 68,
            Items = new List<Item>()
                {
                     new Item() { Title = "Oral Communication", Number = "A1", Units = 4, IsCourse = true},
                     new Item() { Title = "Written Communication", Number = "A2", Units = 4, IsCourse = true },
                     new Item() { Title = "Critical Thinking", Number = "A3", Units = 4, IsCourse = true },
                     new Item() { Title = "Physical Science", Number = "B1", Units = 4, IsCourse = true },
                     new Item() { Title = "Biological Science", Number = "B2", Units = 4, IsCourse = true },
                     new Item() { Title = "Laboratory Activity", Number = "B3", Units = 4, IsCourse = true},
                     new Item() { Title = "Mathematics/Quantitative Reasoning", Number = "B4", Units = 4, IsCourse = true },
                     new Item() { Title = "Science and Technology Synthesis", Number = "B5", Units = 4, IsCourse = true },
                     new Item() { Title = "Visual and Performing Arts", Number = "C1", Units = 4, IsCourse = true },
                     new Item() { Title = "Philosophy and Civilization", Number = "C2", Units = 4, IsCourse = true },
                     new Item() { Title = "Literature and Foreign Languages", Number = "C3", Units = 4, IsCourse = true},
                     new Item() { Title = "Humanities Synthesis", Number = "C4", Units = 4, IsCourse = true },
                     new Item() { Title = "United States History", Number = "D1a", Units = 4, IsCourse = true },
                     new Item() { Title = "Introduction to American Government", Number = "D1b", Units = 4, IsCourse = true },
                     new Item() { Title = "History, Economics, and Political Science", Number = "D2", Units = 4, IsCourse = true },
                     new Item() { Title = "Sociology, Anthropology, Ethnic and Gender Studies", Number = "D3", Units = 4, IsCourse = true},
                     new Item() { Title = "Social Science Synthesis", Number = "D4", Units = 4, IsCourse = true },
                     new Item() { Title = "Lifelong Understanding and Self-development", Number = "E", Units = 4, IsCourse = true }
                }
        };
    }
}
