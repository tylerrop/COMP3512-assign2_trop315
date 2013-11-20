using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;
using Content.DataAccess;
using System.Data;

/// <summary>
/// This control will show the related puchases of an artwork
/// </summary>
public partial class Controls_PurchasesControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artworkId = GetQueryString();

        //Fetch the related purchases from an artwork ID found in the query string
        ArtWorkCollection awc = new ArtWorkCollection();
        awc.FetchRelatedPurchases(artworkId, 5);

        relatedPurchasesRepeater.DataSource = awc;
        relatedPurchasesRepeater.DataBind();
    }

    /// <summary>
    /// This is an event handler fo the artwork fav button that will 
    /// add the artwork to the favorites list
    /// </summary>
    protected void AddArtworkFav_OnClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);

        //Get ArtWork Info---------------------------
        int id = Convert.ToInt32(btn.CommandArgument);

        FavBtn favBtn = new FavBtn(id);

        favBtn.addArtworkFav();
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}