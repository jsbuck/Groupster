namespace Groupster.Core
{
	public class GroupViewTemplate
	{
		public string GroupCondition { get; set; }

		public string DayAbbreviation { get; set; }

		public string EventStart { get; set; }

		public string EventEnd { get; set; }

		public string Icon { get; set; }

		public string ItemTemplateTextProperty { get { return DayAbbreviation; } }

		public string ItemTemplateDetailProperty { get { return EventStart + " / " + EventEnd + " - " + GroupCondition; } }
	}
}