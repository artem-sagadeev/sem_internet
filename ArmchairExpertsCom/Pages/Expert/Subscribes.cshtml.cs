﻿using System.Collections.Generic;
using ArmchairExpertsCom.Models;
using ArmchairExpertsCom.Models.Utilities;
using ArmchairExpertsCom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmchairExpertsCom.Pages.Expert
{
    public class Friends : PageModel
    {
        public User Expert { get; private set; }
        
        public IActionResult OnGet(int? id)
        {
            if (!Auth.IsOtherUser(HttpContext))
            {
                Expert = Auth.GetUser(HttpContext);
            
                if (Expert is null)
                    return Redirect("/login?from=expert/friends");
            }
            else
            {
                Expert = Repository.Get<User>(u => u.Id == id);
                if (!((PrivacySettings) Expert.Privacy.First()).AreSubscribesOpen)
                    return Redirect($"/Expert/PrivacyLimit?id={id}");
            }
            
            return Page();
        }
        
        public IActionResult OnPost(int id)
        {
            var subscriber = Auth.GetUser(HttpContext);
            
            if (subscriber is null)
                return Redirect("/login?from=expert");

            var subscribe = Repository.Get<User>(u => u.Id == id);

            if (Auth.IsSubscribed(HttpContext))
            {
                UserActions.UnSubscribe(subscriber, subscribe);
            }
            else
            {
                UserActions.Subscribe(subscriber, subscribe);
            }

            return Redirect(Request.QueryString.Value);
        }
    }
}