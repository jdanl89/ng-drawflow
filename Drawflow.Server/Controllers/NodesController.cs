namespace Drawflow.Server.Controllers;

using Drawflow.Server.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NodesController : ControllerBase
{
    private static readonly List<NodeElement> _nodes = new()
    {
        new() {
            Id = 1,
            Name = "facebook",
            IconClass = "fa fa-facebook",
            DisplayName = "Facebook Message",
            Inputs = 0,
            Outputs = 1,
            Data = { },
            BodyHtml = null
        },
        new() {
            Id = 2,
            Name = "slack",
            IconClass = "fa fa-slack",
            DisplayName = "Slack receive message",
            Inputs = 1,
            Outputs = 0,
            Data = { },
            BodyHtml = null
        },
        new() {
            Id = 3,
            Name = "github",
            IconClass = "fa fa-github",
            DisplayName = "Github Star",
            Inputs = 0,
            Outputs = 1,
            Data = { { "name", "" } },
            BodyHtml = "<div class=\"box\"><p>Enter repository url</p><input type=\"text\" df-name></div>"
        },
        new() {
            Id = 4,
            Name = "telegram",
            IconClass = "fa fa-telegram",
            DisplayName = "Telegram send message",
            Inputs = 1,
            Outputs = 0,
            Data = { { "channel", "channel_3" } },
            BodyHtml = "<div class=\"box\"><p>Send to telegram</p><p>select channel</p><select df-channel><option value=\"channel_1\">Channel 1</option><option value=\"channel_2\">Channel 2</option><option value=\"channel_3\">Channel 3</option><option value=\"channel_4\">Channel 4</option></select></div>"
        },
        new() {
            Id = 5,
            Name = "aws",
            IconClass = "fa fa-amazon",
            DisplayName = "AWS",
            Inputs = 1,
            Outputs = 1,
            Data = { { "db", new { dbname= "", key= "" } } },
            BodyHtml = "<div class=\"box\"><p>Save in aws</p><input type=\"text\" df-db-dbname placeholder=\"DB name\"><br><br><input type=\"text\" df-db-key placeholder=\"DB key\"></div>"
        },
        new() {
            Id = 6,
            Name = "log",
            IconClass = "fa fa-file-text-o",
            DisplayName = "File Log",
            Inputs = 1,
            Outputs = 0,
            Data = { },
            BodyHtml = null
        },
        new() {
            Id = 7,
            Name = "google",
            IconClass = "fa fa-google",
            DisplayName = "Google Drive save",
            Inputs = 1,
            Outputs = 0,
            Data = { },
            BodyHtml = null
        },
        new() {
            Id = 8,
            Name = "email",
            IconClass = "fa fa-at",
            DisplayName = "Email send",
            Inputs = 1,
            Outputs = 0,
            Data = { },
            BodyHtml = null
        },
        new() {
            Id = 9,
            Name = "template",
            IconClass = "fa fa-code",
            DisplayName = "Template",
            Inputs = 1,
            Outputs = 1,
            Data = { { "template", "Write your template" } },
            BodyHtml = "<div class=\"box\">Get Vars<textarea df-template></textarea>Output template with vars</div>"
        },
        new() {
            Id = 10,
            Name = "multiple",
            IconClass = "fa fa-code-fork",
            DisplayName = "Multiple inputs/outputs",
            Inputs = 3,
            Outputs = 4,
            Data = { },
            BodyHtml = "<div class=\"box\">Multiple!</div>"
        },
        new() {
            Id = 11,
            Name = "personalized",
            IconClass = "fa fa-pencil",
            DisplayName = "Personalized",
            Inputs = 1,
            Outputs = 1,
            Data = { },
            BodyHtml = null
        },
        new() {
            Id = 12,
            Name = "dbclick",
            IconClass = "fa fa-mouse-pointer",
            DisplayName = "DBClick!",
            Inputs = 1,
            Outputs = 1,
            Data = { { "name", "" } },
            BodyHtml = "<div class=\"box dbclickbox\" (dblclick)=\"showpopup(event)\">Db Click here<div class=\"modal\" style=\"display:none\"><div class=\"modal-content\"><span class=\"close\" onclick=\"closemodal(event)\">&times;</span>Change your variable {name} !<input type=\"text\" df-name></div></div></div>"
        }
    };

    [HttpGet]
    [Route("/api/nodes")]
    public IEnumerable<NodeElement> Get()
    {
        return _nodes;
    }
}