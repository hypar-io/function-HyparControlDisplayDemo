using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace HyparControlDisplayDemo
{
    public static class HyparControlDisplayDemo
    {
        /// <summary>
        /// The HyparControlDisplayDemo function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A HyparControlDisplayDemoOutputs instance containing computed results and the model with any new elements.</returns>
        public static HyparControlDisplayDemoOutputs Execute(Dictionary<string, Model> inputModels, HyparControlDisplayDemoInputs input)
        {
            var output = new HyparControlDisplayDemoOutputs();
            var colorScheme = new ColorScheme(new Dictionary<string, Color>
            {
              {"A", Colors.Red},
              {"B", Colors.Green},
              {"C", Colors.Blue},
              {"D", Colors.Yellow},
              {"E", Colors.Orange},
              {"F", Colors.Purple},
              {"G", Colors.Cyan},
              {"H", Colors.Magenta},
              {"I", Colors.Brown},
              {"J", Colors.Pink},
              {"K", Colors.Teal},
              {"L", Colors.Lime},
              {"M", Colors.Navy},
              {"N", Colors.Olive},
              {"O", Colors.Maroon},
              {"P", Colors.Aqua},
              {"R", Colors.Gray},
              {"S", Colors.Black},
              {"T", Colors.White}
            }, "Label")
            {
                Name = "DemoColorScheme"
            };
            output.Model.AddElement(colorScheme);
            var allowedLabels = new AllowedLabels
            {
                Labels = colorScheme.Mapping.Keys.ToList()
            };
            output.Model.AddElement(allowedLabels);
            var demoElems = colorScheme.Mapping.Keys.Select((label, i) =>
            {
                var color = colorScheme.Mapping[label];
                return new DemoElement
                {
                    Profile = Polygon.Rectangle((i, 0), (i + 1, 1)),
                    Label = label,
                    Material = new Material(label)
                    {
                        Color = color
                    },
                    AddId = $"Original Element {i}"
                };
            });
            demoElems = input.Overrides.Profiles.CreateElements(
              input.Overrides.Additions.Profiles,
              input.Overrides.Removals.Profiles,
              (add) =>
              {
                  var label = add.Value.Label;
                  var color = colorScheme.Mapping[label];
                  return new DemoElement
                  {
                      Profile = add.Value.Profile,
                      Label = label,
                      Material = new Material(label)
                      {
                          Color = color
                      },
                      AddId = add.Id
                  };
              },
              (elem, identity) => elem.AddId == identity.AddId,
              (elem, edit) =>
              {
                  var label = edit.Value.Label;
                  var color = colorScheme.Mapping[label];
                  elem.Profile = edit.Value.Profile ?? elem.Profile;
                  elem.Label = label;
                  elem.Material = new Material(label)
                  {
                      Color = color
                  };
                  return elem;
              },
              demoElems
            );
            output.Model.AddElements(demoElems);
            return output;
        }
    }
}