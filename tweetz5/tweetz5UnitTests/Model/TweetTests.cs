﻿// Copyright (c) 2012 Blue Onion Software - All rights reserved

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tweetz5.Model;

namespace tweetz5UnitTests.Model
{
    [TestClass]
    public class TweetTests
    {
        [TestMethod]
        public void TimeAgoShouldNotifyWhenValueChanges()
        {
            var tweet = new Tweet();
            var called = 0;
            tweet.PropertyChanged += (sender, args) => called += 1;
            tweet.TimeAgo = "20m";
            called.Should().Be(1);
            tweet.TimeAgo = "21m";
            called.Should().Be(2);
            tweet.TimeAgo = "21m";
            called.Should().Be(2);
            tweet.TimeAgo.Should().Be("21m");
        }

        [TestMethod]
        public void ParseStatus()
        {
            const string json = @"[{""created_at"":""Wed Nov 14 23:34:26 +0000 2012"",""id"":268859467377033218,""id_str"":""268859467377033218"",""text"":""RT @itisbritt: Seat warmers and steering wheel warmers were by far one of the best upgrades in my @NissanLEAF #winteriscoming"",""source"":""web"",""truncated"":false,""in_reply_to_status_id"":null,""in_reply_to_status_id_str"":null,""in_reply_to_user_id"":null,""in_reply_to_user_id_str"":null,""in_reply_to_screen_name"":null,""user"":{""id"":25088519,""id_str"":""25088519"",""name"":""Nissan LEAF"",""screen_name"":""NissanLEAF"",""location"":""North America"",""description"":""Official Twitter account of the 2012 Nissan LEAF. Innovation That Excites. Please contact @NissanLEAFHelp for all Customer Service questions."",""url"":""http:\/\/www.nissanusa.com\/leaf"",""entities"":{""url"":{""urls"":[{""url"":""http:\/\/www.nissanusa.com\/leaf"",""expanded_url"":null,""indices"":[0,29]}]},""description"":{""urls"":[]}},""protected"":false,""followers_count"":28321,""friends_count"":3561,""listed_count"":993,""created_at"":""Wed Mar 18 15:15:25 +0000 2009"",""favourites_count"":87,""utc_offset"":-21600,""time_zone"":""Central Time (US & Canada)"",""geo_enabled"":false,""verified"":true,""statuses_count"":4035,""lang"":""en"",""contributors_enabled"":true,""is_translator"":false,""profile_background_color"":""00152A"",""profile_background_image_url"":""http:\/\/a0.twimg.com\/profile_background_images\/699743918\/b131c9b37f778a471ad7e0441cfc58a1.jpeg"",""profile_background_image_url_https"":""https:\/\/si0.twimg.com\/profile_background_images\/699743918\/b131c9b37f778a471ad7e0441cfc58a1.jpeg"",""profile_background_tile"":false,""profile_image_url"":""http:\/\/a0.twimg.com\/profile_images\/2794479635\/2f89214130194ea3e9a50eafc783d62d_normal.png"",""profile_image_url_https"":""https:\/\/si0.twimg.com\/profile_images\/2794479635\/2f89214130194ea3e9a50eafc783d62d_normal.png"",""profile_banner_url"":""https:\/\/si0.twimg.com\/profile_banners\/25088519\/1351802676"",""profile_link_color"":""0084B4"",""profile_sidebar_border_color"":""FFFFFF"",""profile_sidebar_fill_color"":""C0DFEC"",""profile_text_color"":""333333"",""profile_use_background_image"":true,""default_profile"":false,""default_profile_image"":false,""following"":true,""follow_request_sent"":null,""notifications"":null},""geo"":null,""coordinates"":null,""place"":null,""contributors"":null,""retweeted_status"":{""created_at"":""Wed Nov 14 23:27:58 +0000 2012"",""id"":268857840213557249,""id_str"":""268857840213557249"",""text"":""Seat warmers and steering wheel warmers were by far one of the best upgrades in my @NissanLEAF #winteriscoming"",""source"":""\u003ca href=\""http:\/\/twitter.com\/download\/iphone\"" rel=\""nofollow\""\u003eTwitter for iPhone\u003c\/a\u003e"",""truncated"":false,""in_reply_to_status_id"":null,""in_reply_to_status_id_str"":null,""in_reply_to_user_id"":null,""in_reply_to_user_id_str"":null,""in_reply_to_screen_name"":null,""user"":{""id"":27899607,""id_str"":""27899607"",""name"":""Britt Lighthizer"",""screen_name"":""itisbritt"",""location"":""Keller \/ Southlake, Texas, USA"",""description"":""MUSIC, MMA, Pursuit of Happiness, Self-Improvement & clothing! \/\/ Go after what you want. "",""url"":""http:\/\/facebook.com\/brittni.lighthizer"",""entities"":{""url"":{""urls"":[{""url"":""http:\/\/facebook.com\/brittni.lighthizer"",""expanded_url"":null,""indices"":[0,38]}]},""description"":{""urls"":[]}},""protected"":false,""followers_count"":377,""friends_count"":89,""listed_count"":3,""created_at"":""Tue Mar 31 16:03:15 +0000 2009"",""favourites_count"":137,""utc_offset"":-21600,""time_zone"":""Central Time (US & Canada)"",""geo_enabled"":true,""verified"":false,""statuses_count"":7029,""lang"":""en"",""contributors_enabled"":false,""is_translator"":false,""profile_background_color"":""52CDC4"",""profile_background_image_url"":""http:\/\/a0.twimg.com\/profile_background_images\/657202013\/xa0f89fae380aef5fd9389294d348674.jpeg"",""profile_background_image_url_https"":""https:\/\/si0.twimg.com\/profile_background_images\/657202013\/xa0f89fae380aef5fd9389294d348674.jpeg"",""profile_background_tile"":true,""profile_image_url"":""http:\/\/a0.twimg.com\/profile_images\/2821268990\/664da59e79f1181eb4040f475708b2e3_normal.png"",""profile_image_url_https"":""https:\/\/si0.twimg.com\/profile_images\/2821268990\/664da59e79f1181eb4040f475708b2e3_normal.png"",""profile_banner_url"":""https:\/\/si0.twimg.com\/profile_banners\/27899607\/1351885406"",""profile_link_color"":""6ED5AC"",""profile_sidebar_border_color"":""FFFFFF"",""profile_sidebar_fill_color"":""A7E67C"",""profile_text_color"":""8BDE94"",""profile_use_background_image"":true,""default_profile"":false,""default_profile_image"":false,""following"":null,""follow_request_sent"":null,""notifications"":null},""geo"":null,""coordinates"":null,""place"":null,""contributors"":null,""retweet_count"":1,""entities"":{""hashtags"":[{""text"":""winteriscoming"",""indices"":[95,110]}],""urls"":[],""user_mentions"":[{""screen_name"":""NissanLEAF"",""name"":""Nissan LEAF"",""id"":25088519,""id_str"":""25088519"",""indices"":[83,94]}]},""retweeted"":false},""retweet_count"":1,""entities"":{""hashtags"":[{""text"":""winteriscoming"",""indices"":[110,125]}],""urls"":[],""user_mentions"":[{""screen_name"":""itisbritt"",""name"":""Britt Lighthizer"",""id"":27899607,""id_str"":""27899607"",""indices"":[3,13]},{""screen_name"":""NissanLEAF"",""name"":""Nissan LEAF"",""id"":25088519,""id_str"":""25088519"",""indices"":[98,109]}]},""favorited"":true,""retweeted"":false}]";
            var status = Status.ParseJson(json);
            status.Length.Should().Be(1);
            status[0].Id.Should().Be("268859467377033218");
            status[0].User.Name.Should().Be("Nissan LEAF");
            status[0].Favorited.Should().BeTrue();
        }

        [TestMethod]
        public void CreateTweetContainsNodeList()
        {
            const string json = @"[{""created_at"":""Wed Nov 14 23:34:26 +0000 2012"",""id"":268859467377033218,""id_str"":""268859467377033218"",""text"":""RT @itisbritt: Seat warmers and steering wheel warmers were by far one of the best upgrades in my @NissanLEAF #winteriscoming"",""source"":""web"",""truncated"":false,""in_reply_to_status_id"":null,""in_reply_to_status_id_str"":null,""in_reply_to_user_id"":null,""in_reply_to_user_id_str"":null,""in_reply_to_screen_name"":null,""user"":{""id"":25088519,""id_str"":""25088519"",""name"":""Nissan LEAF"",""screen_name"":""NissanLEAF"",""location"":""North America"",""description"":""Official Twitter account of the 2012 Nissan LEAF. Innovation That Excites. Please contact @NissanLEAFHelp for all Customer Service questions."",""url"":""http:\/\/www.nissanusa.com\/leaf"",""entities"":{""url"":{""urls"":[{""url"":""http:\/\/www.nissanusa.com\/leaf"",""expanded_url"":null,""indices"":[0,29]}]},""description"":{""urls"":[]}},""protected"":false,""followers_count"":28321,""friends_count"":3561,""listed_count"":993,""created_at"":""Wed Mar 18 15:15:25 +0000 2009"",""favourites_count"":87,""utc_offset"":-21600,""time_zone"":""Central Time (US & Canada)"",""geo_enabled"":false,""verified"":true,""statuses_count"":4035,""lang"":""en"",""contributors_enabled"":true,""is_translator"":false,""profile_background_color"":""00152A"",""profile_background_image_url"":""http:\/\/a0.twimg.com\/profile_background_images\/699743918\/b131c9b37f778a471ad7e0441cfc58a1.jpeg"",""profile_background_image_url_https"":""https:\/\/si0.twimg.com\/profile_background_images\/699743918\/b131c9b37f778a471ad7e0441cfc58a1.jpeg"",""profile_background_tile"":false,""profile_image_url"":""http:\/\/a0.twimg.com\/profile_images\/2794479635\/2f89214130194ea3e9a50eafc783d62d_normal.png"",""profile_image_url_https"":""https:\/\/si0.twimg.com\/profile_images\/2794479635\/2f89214130194ea3e9a50eafc783d62d_normal.png"",""profile_banner_url"":""https:\/\/si0.twimg.com\/profile_banners\/25088519\/1351802676"",""profile_link_color"":""0084B4"",""profile_sidebar_border_color"":""FFFFFF"",""profile_sidebar_fill_color"":""C0DFEC"",""profile_text_color"":""333333"",""profile_use_background_image"":true,""default_profile"":false,""default_profile_image"":false,""following"":true,""follow_request_sent"":null,""notifications"":null},""geo"":null,""coordinates"":null,""place"":null,""contributors"":null,""retweeted_status"":{""created_at"":""Wed Nov 14 23:27:58 +0000 2012"",""id"":268857840213557249,""id_str"":""268857840213557249"",""text"":""Seat warmers and steering wheel warmers were by far one of the best upgrades in my @NissanLEAF #winteriscoming"",""source"":""\u003ca href=\""http:\/\/twitter.com\/download\/iphone\"" rel=\""nofollow\""\u003eTwitter for iPhone\u003c\/a\u003e"",""truncated"":false,""in_reply_to_status_id"":null,""in_reply_to_status_id_str"":null,""in_reply_to_user_id"":null,""in_reply_to_user_id_str"":null,""in_reply_to_screen_name"":null,""user"":{""id"":27899607,""id_str"":""27899607"",""name"":""Britt Lighthizer"",""screen_name"":""itisbritt"",""location"":""Keller \/ Southlake, Texas, USA"",""description"":""MUSIC, MMA, Pursuit of Happiness, Self-Improvement & clothing! \/\/ Go after what you want. "",""url"":""http:\/\/facebook.com\/brittni.lighthizer"",""entities"":{""url"":{""urls"":[{""url"":""http:\/\/facebook.com\/brittni.lighthizer"",""expanded_url"":null,""indices"":[0,38]}]},""description"":{""urls"":[]}},""protected"":false,""followers_count"":377,""friends_count"":89,""listed_count"":3,""created_at"":""Tue Mar 31 16:03:15 +0000 2009"",""favourites_count"":137,""utc_offset"":-21600,""time_zone"":""Central Time (US & Canada)"",""geo_enabled"":true,""verified"":false,""statuses_count"":7029,""lang"":""en"",""contributors_enabled"":false,""is_translator"":false,""profile_background_color"":""52CDC4"",""profile_background_image_url"":""http:\/\/a0.twimg.com\/profile_background_images\/657202013\/xa0f89fae380aef5fd9389294d348674.jpeg"",""profile_background_image_url_https"":""https:\/\/si0.twimg.com\/profile_background_images\/657202013\/xa0f89fae380aef5fd9389294d348674.jpeg"",""profile_background_tile"":true,""profile_image_url"":""http:\/\/a0.twimg.com\/profile_images\/2821268990\/664da59e79f1181eb4040f475708b2e3_normal.png"",""profile_image_url_https"":""https:\/\/si0.twimg.com\/profile_images\/2821268990\/664da59e79f1181eb4040f475708b2e3_normal.png"",""profile_banner_url"":""https:\/\/si0.twimg.com\/profile_banners\/27899607\/1351885406"",""profile_link_color"":""6ED5AC"",""profile_sidebar_border_color"":""FFFFFF"",""profile_sidebar_fill_color"":""A7E67C"",""profile_text_color"":""8BDE94"",""profile_use_background_image"":true,""default_profile"":false,""default_profile_image"":false,""following"":null,""follow_request_sent"":null,""notifications"":null},""geo"":null,""coordinates"":null,""place"":null,""contributors"":null,""retweet_count"":1,""entities"":{""hashtags"":[{""text"":""winteriscoming"",""indices"":[95,110]}],""urls"":[],""user_mentions"":[{""screen_name"":""NissanLEAF"",""name"":""Nissan LEAF"",""id"":25088519,""id_str"":""25088519"",""indices"":[83,94]}]},""retweeted"":false},""retweet_count"":1,""entities"":{""hashtags"":[{""text"":""winteriscoming"",""indices"":[110,125]}],""urls"":[],""user_mentions"":[{""screen_name"":""itisbritt"",""name"":""Britt Lighthizer"",""id"":27899607,""id_str"":""27899607"",""indices"":[3,13]},{""screen_name"":""NissanLEAF"",""name"":""Nissan LEAF"",""id"":25088519,""id_str"":""25088519"",""indices"":[98,109]}]},""favorited"":true,""retweeted"":false}]";
            var status = Status.ParseJson(json);
            var tweet = status[0].CreateTweet(TweetClassification.Home);
            tweet.MarkupNodes.Length.Should().Be(4);
            tweet.MarkupNodes[0].MarkupNodeType.Should().Be(MarkupNodeType.Text);
            tweet.MarkupNodes[1].MarkupNodeType.Should().Be(MarkupNodeType.Mention);
            tweet.MarkupNodes[2].MarkupNodeType.Should().Be(MarkupNodeType.Text);
            tweet.MarkupNodes[3].MarkupNodeType.Should().Be(MarkupNodeType.HashTag);
        }
    }
}