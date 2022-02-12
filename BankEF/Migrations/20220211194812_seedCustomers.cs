using Microsoft.EntityFrameworkCore.Migrations;

namespace BankEF.Migrations
{
    public partial class seedCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into Customers (FirstName, LastName, email, Balance) values ('Blane', 'Stangoe', 'bstangoe0@networkadvertising.org', '1289.01');
insert into Customers(FirstName, LastName, email, Balance) values('Leonelle', 'Natte', 'lnatte1@spotify.com', '3936.44');
            insert into Customers(FirstName, LastName, email, Balance) values('Robbi', 'Brasher', 'rbrasher2@tuttocitta.it', '4785.81');
            insert into Customers(FirstName, LastName, email, Balance) values('Randi', 'Loy', 'rloy3@posterous.com', '1960.09');
            insert into Customers(FirstName, LastName, email, Balance) values('Philly', 'Dolbey', 'pdolbey4@constantcontact.com', '2489.11');
            insert into Customers(FirstName, LastName, email, Balance) values('Lissy', 'Casier', 'lcasier5@wix.com', '3714.95');
            insert into Customers(FirstName, LastName, email, Balance) values('Minnie', 'Ditt', 'mditt6@goo.gl', '329.70');
            insert into Customers(FirstName, LastName, email, Balance) values('Rozalie', 'Haysey', 'rhaysey7@rakuten.co.jp', '1312.48');
            insert into Customers(FirstName, LastName, email, Balance) values('Frannie', 'Batha', 'fbatha8@delicious.com', '2364.54');
            insert into Customers(FirstName, LastName, email, Balance) values('Raimund', 'Souter', 'rsouter9@cafepress.com', '1228.24');
            insert into Customers(FirstName, LastName, email, Balance) values('Eachelle', 'Penrith', 'epenritha@mashable.com', '4136.72');
            insert into Customers(FirstName, LastName, email, Balance) values('Birk', 'Arnall', 'barnallb@dagondesign.com', '1850.17');
            insert into Customers(FirstName, LastName, email, Balance) values('Pris', 'Hutfield', 'phutfieldc@shop-pro.jp', '2926.76');
            insert into Customers(FirstName, LastName, email, Balance) values('Tallia', 'Koppes', 'tkoppesd@so-net.ne.jp', '2410.41');
            insert into Customers(FirstName, LastName, email, Balance) values('Tallou', 'Jaram', 'tjarame@geocities.com', '231.03'); ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Customers");

        }
    }
}
