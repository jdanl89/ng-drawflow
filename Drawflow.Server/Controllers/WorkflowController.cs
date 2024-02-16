namespace Drawflow.Server.Controllers;

using Drawflow.Server.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkflowController : ControllerBase
{
    private static readonly Drawing _drawing = new()
    {
        Drawflow = new()
        {
            Home = new()
            {
                Data =
                {
                    {
                        "1",
                        new()
                        {
                            Id = 1,
                            Name = "welcome",
                            Class = "welcome",
                            Html =
                                "\n    <div>\n      <div class=\"title-box\">👏 Welcome!!</div>\n      <div class=\"box\">\n        <p>Simple flow library <b>demo</b>\n        <a href=\"https://github.com/jerosoler/Drawflow\" target=\"_blank\">Drawflow</a> by <b>Jero Soler</b></p><br>\n\n        <p>Multiple input / outputs<br>\n           Data sync nodes<br>\n           Import / export<br>\n           Modules support<br>\n           Simple use<br>\n           Type: Fixed or Edit<br>\n           Events: view console<br>\n           Pure Javascript<br>\n        </p>\n        <br>\n        <p><b><u>Shortkeys:</u></b></p>\n        <p>🎹 <b>Delete</b> for remove selected<br>\n        💠 Mouse Left Click == Move<br>\n        ❌ Mouse Right == Delete Option<br>\n        🔍 Ctrl + Wheel == Zoom<br>\n        📱 Mobile support<br>\n        ...</p>\n      </div>\n    </div>\n    ",
                            TypeNode = false,
                            PosX = 50,
                            PosY = 50
                        }
                    },
                    {
                        "2", new()
                        {
                            Id = 2,
                            Name = "slack",
                            Class = "slack",
                            Html =
                                "\n          <div>\n            <div class=\"title-box\"><i class=\"fa fa-slack\"></i> Slack chat message</div>\n          </div>\n          ",
                            TypeNode = false,
                            Inputs = new()
                            {
                                { "input_1", new() { Connections = [new() { Node = "7", Input = "output_1" }] } }
                            },
                            PosX = 1028,
                            PosY = 87
                        }
                    },
                    {
                        "3", new()
                        {
                            Id = 3,
                            Name = "telegram",
                            Data = new() { { "channel", "channel_2" } },
                            Class = "telegram",
                            Html =
                                "\n          <div>\n            <div class=\"title-box\"><i class=\"fa fa-telegram\"></i> Telegram bot</div>\n            <div class=\"box\">\n              <p>Send to telegram</p>\n              <p>select channel</p>\n              <select df-channel>\n                <option value=\"channel_1\">Channel 1</option>\n                <option value=\"channel_2\">Channel 2</option>\n                <option value=\"channel_3\">Channel 3</option>\n                <option value=\"channel_4\">Channel 4</option>\n              </select>\n            </div>\n          </div>\n          ",
                            TypeNode = false,
                            Inputs = new()
                            {
                                { "input_1", new() { Connections = [new() { Node = "7", Input = "output_1" }] } }
                            },
                            PosX = 1032,
                            PosY = 184
                        }
                    },
                    {
                        "4", new()
                        {
                            Id = 4,
                            Name = "email",
                            Class = "email",
                            Html =
                                "\n            <div>\n              <div class=\"title-box\"><i class=\"fa fa-at\"></i> Send Email </div>\n            </div>\n            ",
                            TypeNode = false,
                            Inputs =
                            {
                                { "input_1", new() { Connections = [new() { Node = "5", Input = "output_1" }] } }
                            },
                            PosX = 1033,
                            PosY = 439
                        }
                    },
                    {
                        "5", new()
                        {
                            Id = 5,
                            Name = "template",
                            Data =
                            {
                                { "template", "Write your template" }
                            },
                            Class = "template",
                            Html =
                                "\n            <div>\n              <div class=\"title-box\"><i class=\"fa fa-code\"></i> Template</div>\n              <div class=\"box\">\n                Ger Vars<br/>\n                <textarea df-template></textarea><br/>\n                Output template with vars\n              </div>\n            </div>\n            ",
                            TypeNode = false,
                            Inputs =
                            {
                                {
                                    "input_1", new()
                                    {
                                        Connections =
                                        [
                                            new()
                                            {
                                                Node = "6", Input = "output_1"
                                            }
                                        ]
                                    }
                                }
                            },
                            Outputs =
                            {
                                {
                                    "output_1", new()
                                    {
                                        Connections =
                                        [
                                            new()
                                            {
                                                Node = "4",
                                                Output = "input_1"
                                            },

                                            new()
                                            {
                                                Node = "11", Output = "input_1"
                                            }
                                        ]
                                    }
                                }
                            },
                            PosX = 607,
                            PosY = 304
                        }
                    },
                    {
                        "6",
                        new()
                        {
                            Id = 6,
                            Name = "github",
                            Data = { { "Name", "https://github.com/jerosoler/Drawflow" } },
                            Class = "github",
                            Html =
                                "\n          <div>\n            <div class=\"title-box\"><i class=\"fa fa-github \"></i> Github Stars</div>\n            <div class=\"box\">\n              <p>Enter repository url</p>\n            <input type=\"text\" df-name>\n            </div>\n          </div>\n          ",
                            TypeNode = false,
                            Outputs =
                            {
                                {
                                    "output_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new()
                                            {
                                                Node = "5", Output = "input_1"
                                            }
                                        ]
                                    }
                                }
                            },
                            PosX = 341,
                            PosY = 191
                        }
                    },
                    {
                        "7",
                        new()
                        {
                            Id = 7,
                            Name = "facebook",
                            Class = "facebook",
                            Html =
                                "\n        <div>\n          <div class=\"title-box\"><i class=\"fa fa-facebook\"></i> Facebook Message</div>\n        </div>\n        ",
                            TypeNode = false,
                            Outputs =
                            {
                                {
                                    "output_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "2", Output = "input_1" },
                                            new() { Node = "3", Output = "input_1" },
                                            new() { Node = "11", Output = "input_1" }
                                        ]
                                    }
                                }
                            },
                            PosX = 347,
                            PosY = 87
                        }
                    },
                    {
                        "11",
                        new()
                        {
                            Id = 11,
                            Name = "log",
                            Class = "log",
                            Html =
                                "\n            <div>\n              <div class=\"title-box\"><i class=\"fa fa-file-text-o\"></i> Save log file </div>\n            </div>\n            ",
                            TypeNode = false,
                            Inputs =
                            {
                                {
                                    "input_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "5", Input = "output_1" },
                                            new() { Node = "7", Input = "output_1" }
                                        ]
                                    }
                                }
                            },
                            PosX = 1031,
                            PosY = 363
                        }
                    }
                }
            },
            Other = new()
            {
                Data =
                {
                    {
                        "8",
                        new()
                        {
                            Id = 8,
                            Name = "personalized",
                            Class = "personalized",
                            Html = "\n            <div>\n              Personalized\n            </div>\n            ",
                            TypeNode = false,
                            Inputs =
                            {
                                {
                                    "input_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "12", Input = "output_1" },
                                            new() { Node = "12", Input = "output_2" },
                                            new() { Node = "12", Input = "output_3" },
                                            new() { Node = "12", Input = "output_4" }
                                        ]
                                    }
                                }
                            },
                            Outputs =
                            {
                                {
                                    "output_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "9", Output = "input_1" }
                                        ]
                                    }
                                }
                            },
                            PosX = 764,
                            PosY = 227
                        }
                    },
                    {
                        "9",
                        new()
                        {
                            Id = 9,
                            Name = "dbclick",
                            Data = { { "Name", "Hello World!!" } },
                            Class = "dbclick",
                            Html =
                                "\n            <div>\n            <div class=\"title-box\"><i class=\"fa fa-mouse\"></i> Db Click</div>\n              <div class=\"box dbclickbox\" ondblclick=\"showpopup(event)\">\n                Db Click here\n                <div class=\"modal\" style=\"display:none\">\n                  <div class=\"modal-content\">\n                    <span class=\"close\" onclick=\"closemodal(event)\">&times;</span>\n                    Change your variable {name} !\n                    <input type=\"text\" df-name>\n                  </div>\n\n                </div>\n              </div>\n            </div>\n            ",
                            TypeNode = false,
                            Inputs =
                            {
                                {
                                    "input_1",
                                    new() { Connections = [new() { Node = "8", Input = "output_1" }] }
                                }
                            },
                            Outputs =
                            {
                                {
                                    "output_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "12", Output = "input_2" }
                                        ]
                                    }
                                }
                            },
                            PosX = 209,
                            PosY = 38
                        }
                    },
                    {
                        "12",
                        new()
                        {
                            Id = 12,
                            Name = "multiple",
                            Class = "multiple",
                            Html =
                                "\n            <div>\n              <div class=\"box\">\n                Multiple!\n              </div>\n            </div>\n            ",
                            TypeNode = false,
                            Inputs =
                            {
                                {
                                    "input_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new()
                                        ]
                                    }
                                },
                                {
                                    "input_2",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "9", Input = "output_1" }
                                        ]
                                    }
                                },
                                {
                                    "input_3",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new()
                                        ]
                                    }
                                }
                            },
                            Outputs =
                            {
                                {
                                    "output_1",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "8", Output = "input_1" }
                                        ]
                                    }
                                },
                                {
                                    "output_2",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "8", Output = "input_1" }
                                        ]
                                    }
                                },
                                {
                                    "output_3",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "8", Output = "input_1" }
                                        ]
                                    }
                                },
                                {
                                    "output_4",
                                    new()
                                    {
                                        Connections =
                                        [
                                            new() { Node = "8", Output = "input_1" }
                                        ]
                                    }
                                }
                            },
                            PosX = 179,
                            PosY = 272
                        }
                    }
                }
            }
        }
    };

    [HttpGet]
    [Route("/api/workflows/{workflowId}/drawing")]
    public Drawing GetDrawing(long workflowId)
    {
        return _drawing;
    }
}