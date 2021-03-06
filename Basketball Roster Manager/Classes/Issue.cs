﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Creates an issue that can be submitted to Github
/// </summary>
class Issue
{
    private string repository = "JoshuaCarroll/BasketballRosterManager";
    public string title;
    public string[] labels;
    public string body;
    public string Url
    {
        get
        {
            string u = "https://github.com/" + repository + "/issues/new?";
            u += "title=" + Uri.EscapeDataString(this.title) + "&";

            if (labels != null)
            {
                for (int i = 0; i < this.labels.Length; i++)
                {
                    u += "labels%5B%5D=" + Uri.EscapeDataString(this.labels[i]) + "&";
                }
            }

            u += "body=" + Uri.EscapeDataString(this.body);

            return u;
        }
    }

    public void append(string text)
    {
        if (text == null) { text = string.Empty; }
        this.body += "\r\n" + text + "\r\n";
    }

    public void appendCode(string code)
    {
        if (code == null) { code = string.Empty; }
        this.body += "\r\n```\r\n" + code + "\r\n```\r\n";
    }

    public void appendCode(string codeTitle, string code)
    {
        if (code == null) { code = string.Empty; }
        this.body += "\r\n### " + codeTitle + "\r\n```\r\n" + code + "\r\n```\r\n";
    }

    public void appendQuote(string text)
    {
        this.body += "\r\n> " + text.Replace("\r\n", "\r\n> ") + "\r\n";
    }

    public void appendQuote(string quoteTitle, string text)
    {
        if (text == null) { text = string.Empty; }
        this.body += "\r\n### " + quoteTitle + "\r\n> " + text.Replace("\r\n", "\r\n> ") + "\r\n";
    }

    public void appendException(Exception exception)
    {
        appendQuote("Message", exception.Message);
        appendQuote("Help link", exception.HelpLink);
        appendQuote("Source", exception.Source);
        appendQuote("Stack trace", exception.StackTrace);
    }

    public Issue() { }

    public Issue(string title)
    {
        this.title = title;
    }

    public Issue(string title, string body)
    {
        this.title = title;
        this.body = body;
    }

    public void submit()
    {
        System.Diagnostics.Process.Start(Url);
    }
}