namespace Drawflow.Server.Services;

using Drawflow.Server.Models;
using Drawflow.Server.Models.Drawflow;

public class ModuleService : IModuleService
{
    #region Data

    private readonly List<Module> _modules = [
        new()
        {
            ModuleId = 1,
            LongName = "facebook",
            IconClass = "fa fa-facebook",
            ShortName = "Facebook Message",
            InputCount = 0,
            OutputCount = 1,
            BodyHtml = null
        },

        new()
        {
            ModuleId = 2,
            LongName = "slack",
            IconClass = "fa fa-slack",
            ShortName = "Slack receive message",
            InputCount = 1,
            OutputCount = 0,
            BodyHtml = null
        },

        new()
        {
            ModuleId = 3,
            LongName = "github",
            IconClass = "fa fa-github",
            ShortName = "Github Star",
            InputCount = 0,
            OutputCount = 1,
            InputMap = { { "name", "" } },
            BodyHtml = "<div class=\"box\"><p>Enter repository url</p><input type=\"text\" df-name></div>"
        },

        new()
        {
            ModuleId = 4,
            LongName = "telegram",
            IconClass = "fa fa-telegram",
            ShortName = "Telegram send message",
            InputCount = 1,
            OutputCount = 0,
            InputMap = { { "channel", "channel_3" } },
            BodyHtml =
                "<div class=\"box\"><p>Send to telegram</p><p>select channel</p><select df-channel><option value=\"channel_1\">Channel 1</option><option value=\"channel_2\">Channel 2</option><option value=\"channel_3\">Channel 3</option><option value=\"channel_4\">Channel 4</option></select></div>"
        },

        new()
        {
            ModuleId = 5,
            LongName = "aws",
            IconClass = "fa fa-amazon",
            ShortName = "AWS",
            InputCount = 1,
            OutputCount = 1,
            InputMap = { { "db", new { dbname = "", key = "" } } },
            BodyHtml =
                "<div class=\"box\"><p>Save in aws</p><input type=\"text\" df-db-dbname placeholder=\"DB name\"><br><br><input type=\"text\" df-db-key placeholder=\"DB key\"></div>"
        },

        new()
        {
            ModuleId = 6,
            LongName = "log",
            IconClass = "fa fa-file-text-o",
            ShortName = "File Log",
            InputCount = 1,
            OutputCount = 0,
            BodyHtml = null
        },

        new()
        {
            ModuleId = 7,
            LongName = "google",
            IconClass = "fa fa-google",
            ShortName = "Google Drive save",
            InputCount = 1,
            OutputCount = 0,
            BodyHtml = null
        },

        new()
        {
            ModuleId = 8,
            LongName = "email",
            IconClass = "fa fa-at",
            ShortName = "Email send",
            InputCount = 1,
            OutputCount = 0,
            BodyHtml = null
        },

        new()
        {
            ModuleId = 9,
            LongName = "template",
            IconClass = "fa fa-code",
            ShortName = "Template",
            InputCount = 1,
            OutputCount = 1,
            InputMap = { { "template", "Write your template" } },
            BodyHtml = "<div class=\"box\">Get Vars<textarea df-template></textarea>Output template with vars</div>"
        },

        new()
        {
            ModuleId = 10,
            LongName = "multiple",
            IconClass = "fa fa-code-fork",
            ShortName = "Multiple inputs/outputs",
            InputCount = 3,
            OutputCount = 4,
            BodyHtml = "<div class=\"box\">Multiple!</div>"
        },

        new()
        {
            ModuleId = 11,
            LongName = "personalized",
            IconClass = "fa fa-pencil",
            ShortName = "Personalized",
            InputCount = 1,
            OutputCount = 1,
            BodyHtml = null
        },

        new()
        {
            ModuleId = 12,
            LongName = "dbclick",
            IconClass = "fa fa-mouse-pointer",
            ShortName = "DBClick!",
            InputCount = 1,
            OutputCount = 1,
            InputMap = { { "name", "" } },
            BodyHtml =
                "<div class=\"box dbclickbox\" (dblclick)=\"showpopup(event)\">Db Click here<div class=\"modal\" style=\"display:none\"><div class=\"modal-content\"><span class=\"close\" onclick=\"closemodal(event)\">&times;</span>Change your variable {name} !<input type=\"text\" df-name></div></div></div>"
        }
    ];

    #endregion Data

    public IEnumerable<Node> GetModuleNodes() => this._modules.Select(m => m.ToNode());
}