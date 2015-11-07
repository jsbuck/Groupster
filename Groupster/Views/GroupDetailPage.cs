using System.Windows.Input;

using Xamarin.Forms;

namespace Groupster.Core
{
    /// <summary>
    ///   A Xamarin.Forms page for displaying employee details.
    /// </summary>
    class GroupDetailPage : ContentPage
    {
        readonly ICommand _deleteCommand;
        readonly Group _group;

        public GroupDetailPage(Group group)
        {
            _group = group;
			Title = string.Format ("  {0}", "Group Detail");

            #region Initialize some properties on the Page
            Padding = new Thickness(20);
            BindingContext = group;
            #endregion

            #region Initialize the command that will be execute when the user clicks on the delete button.
            _deleteCommand =  new Command(() => {
                                             //App.Groups.Remove(_group);
                                             Navigation.PopAsync();
                                         });
            #endregion

            #region Create the controls for the Page.
            Image groupImage = new Image
                                  {
                                      HeightRequest = 200,
                                      Source = ImageSource.FromFile(_group.ImageFile),
                                  };

            // Put the two buttons inside a grid
            Grid buttonsLayout = new Grid
                                 {
                                     ColumnDefinitions =
                                     {
                                         new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                         new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                                     },
                                     Children =
                                     {
                                         { CreateDeleteButton(), 0, 0 },
                                         { CreateSaveButton(), 1, 0 }
                                     }
                                 };

            // Create a grid to hold the Labels & Entry controls.
			var startEntry = new Entry {
				Placeholder = "StartOn"
			};

			startEntry.SetBinding(Entry.TextProperty, new Binding(path: "StartOn", stringFormat: "{0:ddd, MMM d 'at' h:mm tt}"));

            Grid inputGrid = new Grid
                             {
                                 ColumnDefinitions =
                                 {
                                     new ColumnDefinition { Width = GridLength.Auto },
                                     new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                 },
                                 Children =
                                 {
									{ new Label { Text = "Name:", FontFamily = Fonts.SmallTitle.FontFamily, FontSize = Fonts.SmallTitle.FontSize, TextColor = AppColors.SubTitle }, 0, 0 },
									{ new Label { Text = "Biography:", FontFamily = Fonts.SmallTitle.FontFamily, FontSize = Fonts.SmallTitle.FontSize, TextColor = AppColors.SubTitle }, 0, 1 },
									{ new Label { Text = "StartOn: ", XAlign = TextAlignment.End, FontFamily = Fonts.SmallTitle.FontFamily, FontSize = Fonts.SmallTitle.FontSize, TextColor = AppColors.SubTitle }, 0, 2 },
									{ CreateEntryFor("Name"), 1, 0 },
									{ CreateEntryFor("Biography"), 1, 1 },
									{ startEntry, 1, 2 }
									//{ CreateEntryFor("StartOn"), 1, 2 }
                                 }
                             };
            #endregion

            // Add the controls to a StackLayout 
            Content = new StackLayout
                      {
                          Children =
                          {
							  groupImage,
                              inputGrid,
                              buttonsLayout
                          }
                      };
        }

        /// <summary>
        ///   This is the command to invoke when the user wants to delete the employee.
        /// </summary>
        /// <value>The delete employee command.</value>
        public ICommand DeleteGroupCommand { get { return _deleteCommand; } }

        /// <summary>
        ///   Create the save button and assing an event handler to the Clicked event.
        /// </summary>
        /// <returns>The save button.</returns>
        View CreateSaveButton()
        {
            Button saveButton = new Button
                                {
                                    Text = "Save",
                                    BorderRadius = 5,
                                    TextColor = Color.White,
				BackgroundColor = AppColors.BackgroundGrey
                                };

            saveButton.Clicked += async (sender, e) => await Navigation.PopAsync();
            return saveButton;
        }

        /// <summary>
        ///   Create the delete button and setup the data binding to invoke the DeleteGroupCommand.
        /// </summary>
        /// <returns>The delete button.</returns>
        View CreateDeleteButton()
        {
            // First create the button.
            Button deleteButton = new Button
                                  {
                                      Text = "Delete",
                                      BorderRadius = 5,
                                      TextColor = Color.White,
									  BackgroundColor = AppColors.NegativeBackground
                                  };

            // Setup data binding.
            deleteButton.SetBinding(Button.CommandProperty, "DeleteGroupCommand");
            deleteButton.BindingContext = this;
            return deleteButton;
        }

        /// <summary>
        ///   Helper method that will create a Xmaarin.Forms Entry control on the screen.
        /// </summary>
        /// <returns>A Xamarin.Forms Entry control.</returns>
        /// <param name="propertyName">The name of the property to bind to.</param>
        View CreateEntryFor(string propertyName)
        {
            Entry input = new Entry
                          {
                              HorizontalOptions = LayoutOptions.FillAndExpand
                          };
            input.SetBinding(Entry.TextProperty, propertyName);
            return input;
        }
    }
}
