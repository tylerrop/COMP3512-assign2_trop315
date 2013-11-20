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
/// This class will call the code to add an artist or artwork to the favorites
/// list based on the ID of the object to add.
/// </summary>
public class FavBtn
{
    //ID of the object to add to favorites
    public int id;

	public FavBtn(int id)
	{
        this.id = id;
	}

    /// <summary>
    /// Adds the artwork to the artwork favorite list
    /// </summary>
    public void addArtworkFav()
    {
        //Finds the artwork of the ID
        ArtWorkCollection aw = new ArtWorkCollection();
        aw.FetchForId(id);

        //Pulls information the create the favorite item
        string title = aw[0].Title;
        string imgFileName = aw[0].ImageFileName;

        //Creates the favorite item
        ArtWorkFavoriteItem artWorkItem = new ArtWorkFavoriteItem(id, title, imgFileName);

        //Creates the session
        List<ArtWorkFavoriteItem> favArtWorkList = (List<ArtWorkFavoriteItem>)HttpContext.Current.Session["favArtwork"];

        //IF THE SESSION DOSNT EXIST
        if (favArtWorkList == null)
        {
            //Creates a new list of favorite items
            favArtWorkList = new List<ArtWorkFavoriteItem>();
            //Adds the item
            favArtWorkList.Add(artWorkItem);
            //Puts the list in the faveorite list
            HttpContext.Current.Session["favArtwork"] = favArtWorkList;
        }
        //SESSION EXISTS
        else
        {
            //Boolean to see it the item already exists
            bool exists = false;

            //Searches the list to find a matching ID
            foreach (ArtWorkFavoriteItem item in favArtWorkList)
            {
                if (item.Id == artWorkItem.Id)
                    exists = true;
            }

            //Adds the item if it dosnt exist
            if (!exists)
                favArtWorkList.Add(artWorkItem);
        }
    }

    /// <summary>
    /// Adds the artist to the artwork favorite list
    /// </summary>
    public void addArtistFav()
    {
        //Finds the artist of the ID
        ArtistCollection ac = new ArtistCollection(false);
        ac.FetchForId(id);

        //Pulls information the create the favorite item
        string first = ac[0].FirstName;
        string last = ac[0].LastName;

        //Creates the favorite item
        ArtistFavoriteItem artistItem = new ArtistFavoriteItem(id, first, last);

        //Creates the session
        List<ArtistFavoriteItem> favArtistList = (List<ArtistFavoriteItem>)HttpContext.Current.Session["favArtist"];

        //IF THE SESSION DOSNT EXIST
        if (favArtistList == null)
        {
            //Creates a new list of artist item
            favArtistList = new List<ArtistFavoriteItem>();
            //Adds the item
            favArtistList.Add(artistItem);
            //Puts the list in the faveorite list
            HttpContext.Current.Session["favArtist"] = favArtistList;
        }
        //SESSION EXISTS
        else
        {
            //Boolean to see it the item already exists
            bool exists = false;

            //Searches the list to find a matching ID
            foreach (ArtistFavoriteItem item in favArtistList)
            {
                if (item.Id == artistItem.Id)
                    exists = true;
            }

            //Adds the item if it dosnt exist
            if (!exists)
                favArtistList.Add(artistItem);
        }
    }
}