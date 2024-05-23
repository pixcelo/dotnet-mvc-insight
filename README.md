# dotnet-mvc-insight
- .NET8

## 実装
- [ASP.NET Core の HttpContext にアクセスする](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/http-context?view=aspnetcore-8.0)

## ユニットテスト
- [ASP.NET MVC アプリケーションの単体テストを作成する (C#)](https://learn.microsoft.com/ja-jp/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs)

## Meta for Developers Tools
- [グラフAPIエクスプローラ](https://developers.facebook.com/tools/explorer/)
- [アクセストークンデバッガー](https://developers.facebook.com/tools/debug/accesstoken/)

## Server
- [SSH設定](https://www.xserver.ne.jp/manual/man_server_ssh.php)
- [SSHソフトの設定(Tera Term)](https://www.xserver.ne.jp/manual/man_server_ssh_connect_tera.php)

## Database
SQLiteの接続方法<br />
[Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
```powershell
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```
ビルドに失敗する場合、`dotnet ef migrations add InitialCreate -v`で詳細を確認する
```powershell
Build started...
Build failed. Use dotnet build to see the errors.
```

## Reference
- [ビジネス向けFacebookログイン](https://developers.facebook.com/docs/facebook-login/facebook-login-for-business/)
- [ログインフローを手動で構築する](https://developers.facebook.com/docs/facebook-login/guides/advanced/manual-flow)
- [Business Login for Instagram](https://developers.facebook.com/docs/instagram/business-login-for-instagram/)
- [スタートガイド](https://developers.facebook.com/docs/instagram-api/getting-started)
- [インサイト](https://developers.facebook.com/docs/instagram-api/guides/insights)
- [GitHub](https://github.com/search?q=instagram+language%3AC%23+&type=repositories)