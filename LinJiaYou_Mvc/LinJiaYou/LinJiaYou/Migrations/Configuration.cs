namespace LinJiaYou.Migrations
{
    using LinJiaYou.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinJiaYou.Models.LinJiaYouContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LinJiaYou.Models.LinJiaYouContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.Tourists.AddOrUpdate(new Tourist
            //{
            //    Name = "卧龙山自然风景区",
            //    FirstPicUrl = "/Content/images/wolongshan.jpg",
            //    Intro = "卧龙山自然风景区位于河北省遵化市娘娘庄乡，1998年开始规划动工。2000年对外开放。2004年投资350万元，完成了道路开拓、庙宇修建等工程。已经批准为国家2A级景区。",
            //    Is_delete = false,
            //    Pictures = new System.Collections.Generic.List<Picture> {
            //                                        new Picture{Url="/Content/images/wolongshan.jpg" },
            //                                        new Picture{Url="/Content/images/11-02-11_1420.jpg"},
            //                                        new Picture{Url="/Content/images/21-01-12_1410.jpg"},
            //                                        new Picture{Url="/Content/images/bixiagong.jpg"}
            //                                       },
            //    TouristDetail = new TouristDetail
            //    {
            //        Description = @"<p style='text-indent:2em;'>  卧龙山是经中国国家审批的2A级风景旅游区。</p>
            //                            <p>  卧龙山，山势自西向东，峰峦叠起，蜿蜒曲折，连绵不断。大自然的鬼斧神工，造就了龙头峰、龙脊峰、龙腹峰、龙乳峰、龙尾峰。五峰相连，酷似一条横空出世的巨龙在云影烟光中盘旋飞腾，因此叫卧龙山，森林覆盖率达80%，满山数千万株松柏，给山劈山了绿装。山中有好多怪石，裸露山中，形象各异。龙乳峰下的龙乳泉，是天然形成的奇泉，三尺见方，三尺水深。龙乳泉水“四不”奇特无比。</p>
            //                            <p>
            //                                卧龙山凭借大自然赐予的奇特风光依山就势，精心设计建筑了多处人文景观。整体建筑格调为：仿古建筑，砖、木、石结构。
            //                            </p>
            //                            <p>
            //                                山上有抗日烈士纪念碑，高九米，宽三米，汉白玉砌成。碑的四周生长着挺拔的苍松翠柏，碑座上摆放着谒碑人献给先烈的簇簇鲜花。碑身右侧旗杆上鲜艳的五星红旗迎风招展，碑顶的五角红星在为蓝的天空中闪闪发亮。碑身前面刻着“抗日先烈永垂不朽，下峪村民敬立，九九年九月”血红的大字。碑身后面，记述了这次战斗历程。
            //                                在卧龙山的最好地段，龙腹峰的龙心处建有乾坤圣殿（中华伟人馆）。乾坤圣殿（中华伟人馆），在中国是首家由农民自筹资金，自觉修建的纪念馆。
            //                            </p>
            //                            <p>
            //                                卧龙山重建和兴建了九座佛、道殿堂：①天王殿、②观音殿、③娘娘殿、④药王殿、⑤财神殿、⑥龙王殿、⑦地藏王、菩萨殿、⑧大雄宝殿、⑨万佛殿。每年农历二月初二和十月十五有两次传统庙会。
            //                            </p>"
            //    }
            //});
            //context.PhoneVeriCodes.AddOrUpdate(
            //    new PhoneVeriCode
            //    {
            //        AddTime = Convert.ToDateTime("2018-02-21 16:44:42.980"),
            //        Phone = "15832578508",
            //        VerificationCode = "5947"
            //    }, new PhoneVeriCode
            //    {
            //        AddTime = Convert.ToDateTime("2018-03-10 19:07:26.957"),
            //        Phone = "15832578508",
            //        VerificationCode = "7713"
            //    },
            //    new PhoneVeriCode
            //    {
            //        AddTime = Convert.ToDateTime("2018-03-10 23:17:33.330"),
            //        Phone = "15872690013",
            //        VerificationCode = "2134"
            //    }, new PhoneVeriCode
            //    {
            //        AddTime = Convert.ToDateTime("2018-03-10 23:25:51.993"),
            //        Phone = "15827094852",
            //        VerificationCode = "2431"
            //    }
            //    );
            //context.Users.AddOrUpdate(new User
            //{
            //    Name = "15832578508",
            //    Password = "123456",
            //    Phone = "15832578508"
            //},
            //new User
            //{
            //    Name = "15872690013",
            //    Password = " 1234567890",
            //    Phone = "15872690013"
            //}, new User
            //{
            //    Name = "15827094852",
            //    Password = "1234567890",
            //    Phone = "15827094852"
            //});
            //context.Provinces.AddOrUpdate<Province>(
            //    new Province {
            //        Name ="山西",
            //    Citys =new List<City> { 
            //        new City {
            //            Name ="太原",
            //            Countys = new List<County>{
            //            new County{  Name="小店县"},
            //            new County{ Name="迎泽县"}
            //            }
            //                    },
            //        new City {
            //            Name="大同",
            //                        Countys = new List<County>{
            //                            new County{  Name="天镇县"},
            //                            new County{ Name="广灵县"}
            //                        }
            //                    }
            //    }
            //    });
            //context.Managers.Add(new Manager { Name = "admin", Password = "wbl160685" });

        }
    }
}
