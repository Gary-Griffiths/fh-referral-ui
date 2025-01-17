﻿namespace FamilyHubs.ReferralUi.Ui.Models.Links;

public class Privacy : Link
{
    public Privacy(string href, string @class = "") : base(href, @class: @class)
    {
    }

    public override string Render()
    {
        return $"<a href=\"{Href}\" class=\"{Class}\">Privacy</a>";
    }
}
