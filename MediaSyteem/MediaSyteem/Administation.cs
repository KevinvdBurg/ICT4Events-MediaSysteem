﻿using MediaSyteem;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Administation
{
    public Account currentAccount { get; set; }

    private DBLogin dblogin = new DBLogin();
    private DBPost dbpost = new DBPost();

    public void LikePost(int postid)
    {
        dbpost.LikePost(postid);
    }
	public void Add(Post Post, string Inhoud)
	{
	    dbpost.InsertMessage(Post, Inhoud);
	}

    public void Add(Map map)
    {
        dbpost.Insert(map);
    }

	public void Delete(Post Post)
	{
	    dbpost.Delete(Post.Postid.ToString());
	}

	public void Find(Post Post)
	{
		
	}

    public bool login(string username, string password)
    {
        return dblogin.loginCheck(username, password);
        
    }
    
    public void setCurrentAccount(string email)
    {
        this.currentAccount = dblogin.returnLoggedinAccount(email);
    }

    public List<Post> returnAllPosts()
    {
        List<Post> resultaat = new List<Post>();
        resultaat = dbpost.allPosts();
        return resultaat;
    }

    public List<Post> returnAllPosts(int parentmap)
    {
        List<Post> resultaat = new List<Post>();
        resultaat = dbpost.allPosts(parentmap);
        return resultaat;
    }

    public string postTitel(int postid)
    {
        return dbpost.GetTitel(postid);
    }

    public string PostAuteur(int postid)
    {
        return dbpost.GetPostAuteur(postid);
    }

    public int NumberOfReplies(int postid)
    {
        return dbpost.numberOfReplies(postid);
    }
    public string postText(int postid)
    {
        return dbpost.GetText(postid);
    }

    public bool isMessage(int postid)
    {
        return dbpost.isBericht(postid);
    }
    public List<Post> ReturnAllReplies(int postid)
    {
        List<Post> resultaat = new List<Post>();
        resultaat = dbpost.allReplies(postid);
        return resultaat;
    }

    public void ReportPost(int postid)
    {
        dbpost.ReportPost(postid);
    }

    public bool hasParentPost(int postid)
    {
        return dbpost.hasParentPost(postid);
    }

    public int GiveParentPost(int postid)
    {
        return dbpost.returnParentPost(postid);
    }

    public void AddReply(Post Post, string Inhoud)
    {
        dbpost.InsertReply(Post, Inhoud);
    }

    public void Add(File file, Account account)
    {
        dbpost.InsertFile(file, account);
    }

    public List<Map> ReturnMaps()
    {
        return dbpost.allMaps();
    }
    public List<Map> ReturnMaps(int mapid)
    {
        return dbpost.allMaps(mapid);
    }

    public string getParentMapName(int parentmapid)
    {
        return dbpost.parentMapNaam(parentmapid);
    }


}

