using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForestApp_CityApi_DataAccess.Migrations
{
    public partial class cityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onUpdate:ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedOn", "LastAccessed", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 952, DateTimeKind.Utc).AddTicks(5308), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara", null },
                    { new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 952, DateTimeKind.Utc).AddTicks(8142), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antalya", null },
                    { new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 952, DateTimeKind.Utc).AddTicks(8249), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul", null },
                    { new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 952, DateTimeKind.Utc).AddTicks(8257), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İzmir", null },
                    { new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 952, DateTimeKind.Utc).AddTicks(8262), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bursa", null },
                    { new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 952, DateTimeKind.Utc).AddTicks(8270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eskişehir", null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "CreatedOn", "LastAccessed", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("f6d4b274-1d7e-4f56-a78a-100ad49200e5"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(32), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayaş", null },
                    { new Guid("55eaab1b-6002-4bef-91ed-21a6e5812193"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1884), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kemalpaşa / İzmir", null },
                    { new Guid("08f42f9c-5076-46a7-baf9-73691a2021a7"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kınık", null },
                    { new Guid("b9bcfe65-7946-43e2-ab74-fa2a2ee5a368"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1887), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiraz", null },
                    { new Guid("9a341ee2-e108-4c02-ab76-04fb80b26664"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1889), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Menemen", null },
                    { new Guid("f32d96b0-4e1a-458d-aa0e-94bdd1e2b234"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1891), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ödemiş", null },
                    { new Guid("93e5d4c3-beb6-418e-afbc-75609bb0cd43"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1892), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seferihisar", null },
                    { new Guid("db96c1ea-0cd3-4e65-8e11-715a4225c31f"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1883), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karşıyaka", null },
                    { new Guid("4afcad6c-f6ac-4294-9034-8cd0bbb147da"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1896), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Selçuk", null },
                    { new Guid("7ec2871f-1da3-4ab9-905b-d2d0c25be3bd"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torbalı", null },
                    { new Guid("bc6dd89a-1371-4843-95ac-b6b9be61a7c1"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1900), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Urla", null },
                    { new Guid("ecd09611-be83-46f1-9261-68b2b04455ec"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beydağ", null },
                    { new Guid("d6ad0e84-6207-4125-9ae0-1536fc06cee9"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buca", null },
                    { new Guid("12cad8bd-fb1a-453b-926f-1ce36374f9ee"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1905), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konak", null },
                    { new Guid("fdd45586-2a40-4f52-9a1b-ebb56e906448"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1907), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Menderes", null },
                    { new Guid("26e3dfec-5600-4650-bdf4-ef33bb7781ac"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1897), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tire", null },
                    { new Guid("e32ce81e-ec57-418e-ab83-3aff86becd60"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1910), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balçova", null },
                    { new Guid("8e1a8fed-776b-4afb-9522-2a840ef77157"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karaburun", null },
                    { new Guid("ed35c064-b6dd-4561-bc2e-2a440c4aa8f2"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dikili", null },
                    { new Guid("2d04da86-4091-470b-a77f-2321c58eccc0"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1852), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esenler", null },
                    { new Guid("295d89ae-f968-4b13-9c81-a0e1723a8d9f"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arnavutköy", null },
                    { new Guid("f4b28099-bac3-41b7-acf5-9332b817cce6"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1856), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ataşehir", null },
                    { new Guid("1fd0daec-166c-496d-ae3c-cf8cd6f3065a"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Başakşehir", null },
                    { new Guid("2566e714-b1b8-4f5a-a227-74c41606feca"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1859), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beylikdüzü", null },
                    { new Guid("be6c2724-7cb5-44ed-a217-185d6feb1762"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çekmeköy", null },
                    { new Guid("bacb6fa9-febe-488f-be6d-a12e68c6f055"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1878), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foça", null },
                    { new Guid("983f27ec-9c9d-4ada-ac2f-6a39925f18a6"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esenyurt", null },
                    { new Guid("a63ca900-8988-4cd3-9f9b-dd7c954e0052"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sultangazi", null },
                    { new Guid("d5a02456-79d3-43b1-aa18-51ba58562bf1"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aliağa", null },
                    { new Guid("d7aaacbd-b33f-45d3-a9e9-066a1926d71a"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1870), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bayındır", null },
                    { new Guid("19318782-66f0-4c21-b7b8-276d91522855"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bergama", null },
                    { new Guid("03ceccbf-512c-4e64-bc6d-33e5bac677be"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bornova", null },
                    { new Guid("79e9df48-25ef-42d5-9978-f5b5893978c9"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çeşme", null },
                    { new Guid("8a2927bd-533a-492d-8765-2c4dd583fe19"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sancaktepe", null },
                    { new Guid("800b3adb-d96f-4512-b874-b90211a75a03"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1849), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuzla", null },
                    { new Guid("bffb7b88-13d9-44e6-9d9f-bc2d194a4d27"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1912), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çiğli", null },
                    { new Guid("d29c7c54-065d-4836-b312-6505e4c9407f"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1915), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Narlıdere", null },
                    { new Guid("1de12185-f74c-4d2d-96ff-f51a5847f33f"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1981), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gürsu", null },
                    { new Guid("aa7ce1ed-881e-4d55-825a-4e193c7bf516"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1982), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kestel", null },
                    { new Guid("7e5e2030-fef5-4feb-a9c6-ec77d0a7591c"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1988), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çifteler", null },
                    { new Guid("b347170a-bad7-4db2-9522-8372bad4a65c"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1989), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmudiye", null },
                    { new Guid("f681a4cb-35d4-485f-bbe8-71d3ffbf1315"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihalıççık", null },
                    { new Guid("c02df84a-a50b-4b8f-b30d-2a082c89f317"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1992), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarıcakaya", null },
                    { new Guid("261e9970-0256-497b-b914-7d0c8c2adf81"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1979), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yıldırım", null },
                    { new Guid("c6b3a4cf-a992-47ea-a5d6-edd12eb189a0"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1994), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seyitgazi", null },
                    { new Guid("22e1fc98-4dd8-4f77-ad1c-6afcf7c3485f"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1997), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alpu", null },
                    { new Guid("cdda3ddd-88ec-4283-be87-00594c8e4818"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beylikova", null },
                    { new Guid("e8147ac7-f27d-4b7d-a00b-a123a236b71e"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(2002), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İnönü", null },
                    { new Guid("c1411014-69fb-41db-b72a-d617c486f43c"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(2003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Günyüzü", null },
                    { new Guid("e013d037-0f4c-420f-a8b3-ac44a0365e70"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(2005), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Han", null },
                    { new Guid("3fe1ca22-5a7e-4135-a960-c6120d7cc4e7"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(2007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihalgazi", null },
                    { new Guid("1e82fe45-af85-481a-925a-5bc762142f6f"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1996), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sivrihisar", null },
                    { new Guid("b98b604f-c001-476e-992b-a3e1a91c6ab6"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaziemir", null },
                    { new Guid("78725269-2a73-45be-8f05-84490d65b057"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1978), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osmangazi", null },
                    { new Guid("cec2cc85-2257-44e9-8161-99c4839eeddd"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1975), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harmancık", null },
                    { new Guid("d0d8d110-c00c-4172-aac4-c0556a963f09"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1949), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güzelbahçe", null },
                    { new Guid("6f6312d4-6407-43a0-9596-935b180e34ba"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1951), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bayraklı", null },
                    { new Guid("ab6e57a1-b778-43b7-a6d6-961ee0136c8d"), new Guid("fe3f958d-a55c-4e46-9126-a1a2a5b34674"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1952), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karabağlar", null },
                    { new Guid("8522aa5a-5ce7-465b-8ffb-be01eccd6e32"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gemlik", null },
                    { new Guid("37a55a3f-7414-40dd-82be-8f4e5b6cbfd1"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1958), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İnegöl", null },
                    { new Guid("d1804478-2d4a-4380-8489-acd4fc123916"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1959), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İznik", null },
                    { new Guid("d0929799-8d4d-4617-9609-7e549f2d3f72"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1976), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nilüfer", null },
                    { new Guid("8e562b36-4e6d-4a27-a185-abc880835115"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1961), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karacabey", null },
                    { new Guid("77c682c8-41de-4128-8367-cb20f2977c84"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1964), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mudanya", null },
                    { new Guid("c3396655-a6ea-4d6d-adb1-666e0ceeba8f"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1965), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafakemalpaşa", null },
                    { new Guid("b21755f4-38ba-4f84-93f3-47d6510be4e8"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1967), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orhaneli", null },
                    { new Guid("543345fc-2ec6-4632-983f-14c73552e3d7"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1968), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orhangazi", null },
                    { new Guid("25f97d04-03d7-4561-a0f7-c4239eaa905e"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1972), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yenişehir / Bursa", null },
                    { new Guid("722362f5-e38a-400a-b973-ef1f3d238e4b"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1973), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Büyükorhan", null },
                    { new Guid("2ee293c6-9807-449c-84aa-a74171a820d4"), new Guid("ffc28b74-9be7-41ac-8759-60baf56988ee"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1962), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keles", null },
                    { new Guid("ea5c56f4-3bc3-45b1-9ddf-c38c945e587f"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(2008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Odunpazarı", null },
                    { new Guid("b01d5263-b203-4a3c-adc4-2d8a5fc2928e"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1848), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sultanbeyli", null },
                    { new Guid("15731cf8-365c-4a65-a028-9215b3b810e1"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güngören", null },
                    { new Guid("29bbe05d-41a6-4d8f-93bb-e3f2a86e9e18"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1702), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazan", null },
                    { new Guid("6f763cb0-6cd4-4d28-a8c0-160cefc6f4e5"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akyurt", null },
                    { new Guid("7596fca5-469f-4028-aa4c-f26298dcb163"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Etimesgut", null },
                    { new Guid("2c9a20c1-85cb-440a-9c49-27ffcea49100"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1707), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evren", null },
                    { new Guid("bba90293-8e5d-485b-9209-49f147b572a5"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1708), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pursaklar", null },
                    { new Guid("495bb9c7-fdd6-440a-b2ee-fa68142e7402"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1716), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akseki", null },
                    { new Guid("d007275c-ddd3-4a37-8f6f-780709683bba"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1700), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sincan", null },
                    { new Guid("e17fdf4d-0968-4b7b-a2a8-82f7e8ff9f8b"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1720), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alanya", null },
                    { new Guid("ef45a9a8-a9d1-45bc-8701-8ba4ba304a0e"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1723), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finike", null },
                    { new Guid("64954ce5-cda2-4b9d-8603-52a81bdf895c"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1725), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gazipaşa", null },
                    { new Guid("075773cb-562a-4cea-9cf9-77f50d162ab9"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1726), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gündoğmuş", null },
                    { new Guid("35ed1365-1071-4816-8997-c9e483ca76f5"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1728), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaş", null },
                    { new Guid("4983b85d-5571-409d-bcf1-b1387f6e7d22"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1729), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korkuteli", null },
                    { new Guid("bf03265b-b95e-4cb3-a3eb-62c828d5b36d"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1731), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumluca", null },
                    { new Guid("7632c38e-2d70-4d71-9f69-a74aa890b024"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1722), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elmalı", null },
                    { new Guid("ee19bbb4-10b9-4d33-9269-92104e5c17ee"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1736), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manavgat", null },
                    { new Guid("4e0356b1-10ad-495f-8b88-0c3fd88929e8"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mamak", null },
                    { new Guid("2afbc722-90d0-428d-8123-db822562de89"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1692), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gölbaşı", null },
                    { new Guid("b07e8ecd-ea91-4986-8978-7f550ed59b80"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1621), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bala", null },
                    { new Guid("dafe0639-b8e4-4ecb-98f7-c1c454c443f1"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1660), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beypazarı", null },
                    { new Guid("daaf7086-09c8-48dd-92d4-f5eda6daf6e4"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1662), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çamlıdere", null },
                    { new Guid("776a0e54-f0d6-4322-ac85-28f5292c05a6"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1664), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çankaya", null },
                    { new Guid("af2cd559-dd78-422d-a820-0a4aede0b238"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çubuk", null },
                    { new Guid("6f85bdfd-cfcc-4773-889e-65ea673d47a1"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1670), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elmadağ", null },
                    { new Guid("c6c6335f-4cff-4595-bc9b-a2c742f9d2d6"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1694), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keçiören", null },
                    { new Guid("0300eafc-e9e4-44c2-8ebc-9c495cb8139e"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Güdül", null },
                    { new Guid("1ebc0ecf-886b-4432-9e8a-8158e2789816"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1682), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalecik", null },
                    { new Guid("e68ebf9c-2f28-46a6-a078-1127995d5cb0"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1684), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kızılcahamam", null },
                    { new Guid("7d60310d-6eb2-4443-af9d-eb873680c9a1"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1685), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nallıhan", null },
                    { new Guid("7a097fd9-1503-474d-8e7c-f42eb6949a26"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1687), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Polatlı", null },
                    { new Guid("df38c5b5-ab63-46e4-a6b8-3924ee2f699f"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şereflikoçhisar", null },
                    { new Guid("f42dc3f5-e1fa-4308-93b8-26c3f7300c59"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1690), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yenimahalle", null },
                    { new Guid("4e8ed2fa-ac91-4671-83f2-cd084a58aecf"), new Guid("5fa72a26-49a3-4d72-a5ce-e935c74ba887"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1673), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haymana", null },
                    { new Guid("13299cee-8f5c-478f-a105-9f11bbc0ed79"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1846), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maltepe", null },
                    { new Guid("86228c25-0ca1-4b25-bf3d-ece4eea2ad30"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serik", null },
                    { new Guid("17fdcc65-664d-4d45-a16f-13930d6c4ce9"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1785), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İbradı", null },
                    { new Guid("801de37a-ac0e-4071-98ea-5a0275b61e0b"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silivri", null },
                    { new Guid("51ca42e9-5dcf-48b0-868d-b81ce045f8ba"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1820), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şile", null },
                    { new Guid("22005864-8271-4d4e-ad1d-00629ac3538e"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1823), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şişli", null },
                    { new Guid("235bd516-e109-4d29-9587-38031fa3b419"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1825), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üsküdar", null },
                    { new Guid("fdc7594a-ab0c-465a-9043-67715e0791c7"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1826), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zeytinburnu", null },
                    { new Guid("77b89944-efc4-4b6b-8a9e-1378302540e7"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1828), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Büyükçekmece", null },
                    { new Guid("dad1049d-02bb-4d9f-9a89-e0bb0ab3273c"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1817), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarıyer", null },
                    { new Guid("a5d43e71-bfc7-468e-9eeb-7c4e9db8bc3f"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1829), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kağıthane", null },
                    { new Guid("8beb7c40-c423-4207-9d96-18f685f02e45"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1832), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pendik", null },
                    { new Guid("1eee5e67-bc8a-4147-8c07-122c751c736d"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1834), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ümraniye", null },
                    { new Guid("978adb24-b6e1-414d-b3ad-cbaf14c9a112"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1838), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bayrampaşa", null },
                    { new Guid("669e579e-e2de-43dc-8a5e-a59c82a4a617"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avcılar", null },
                    { new Guid("1a77093e-ce61-4f3b-8edb-0506d2a78900"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1841), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bağcılar", null },
                    { new Guid("3d7731e8-69c6-4950-a7d3-32012f902597"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1843), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahçelievler", null },
                    { new Guid("60ef61c4-3372-42e7-b03a-deed7dcdeb62"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1831), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Küçükçekmece", null },
                    { new Guid("583944d6-4142-4a3b-a30f-25427e4c485e"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1783), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demre", null },
                    { new Guid("ddaa99ab-a5d6-41d4-a859-2d115e9b254a"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1815), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kartal", null },
                    { new Guid("e5969096-9e50-4e76-b447-77f8702328a3"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1812), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaziosmanpaşa", null },
                    { new Guid("e37aaa8b-0fa9-4af2-ac3f-7213a45519d7"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kemer / Antalya", null },
                    { new Guid("30dac76c-cc05-49c4-b896-ba2044241a99"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1788), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aksu / Antalya", null },
                    { new Guid("91334eac-14a5-4139-831d-e63e26965ea9"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Döşemealtı", null },
                    { new Guid("5a25ba5b-b3d0-42e4-bee3-a8f006d0bcbf"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1791), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kepez", null },
                    { new Guid("a54d11b5-9ef2-4318-b612-a1430019506d"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1795), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konyaaltı", null },
                    { new Guid("994b3096-928f-4de3-b42c-195130539daf"), new Guid("f3a532cf-8321-4633-9bfd-10711e3a7aa8"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1796), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muratpaşa", null },
                    { new Guid("e58d5c73-0a6b-4a1a-ba2a-6fd810aab465"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1813), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kadıköy", null },
                    { new Guid("3cb3d2dd-3d04-4f89-8832-71f429c072d0"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1798), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adalar", null },
                    { new Guid("7faba713-a95f-4bbc-87eb-c16c19fc1c68"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1801), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beşiktaş", null },
                    { new Guid("31bd3dd9-614e-4715-b156-daeaa6b35d9d"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beykoz", null },
                    { new Guid("cc1fe17a-8254-4c3f-8ecf-4057ec318e5d"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1804), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beyoğlu", null },
                    { new Guid("e63ad0d4-f1ee-47b3-85c0-bd044d2e333a"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1806), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çatalca", null },
                    { new Guid("8cf0c832-1126-4970-85a4-e5745df6f3c7"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1809), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eyüp", null },
                    { new Guid("9f6cd71d-3ed8-4af6-9217-4c36b996702b"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1810), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fatih", null },
                    { new Guid("59f6baa0-21c4-4b2f-86de-c83988026477"), new Guid("0e3921a6-e2f1-4492-8cdc-b36662c6fc74"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(1800), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bakırköy", null },
                    { new Guid("d01e3cb9-8340-4894-b00b-10e359f922d4"), new Guid("6555fbc4-d38a-44dd-955f-3d81db6c536a"), new DateTime(2021, 2, 12, 7, 39, 15, 954, DateTimeKind.Utc).AddTicks(2010), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tepebaşı", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
