# Bingo

A tiny side project. The end goal is that an user can create a board and share it with others.  
There is a */streamer* Route to embedd it in streams. Everyone that has the URL can click on the fields, which will send through Websockets to everyone.  

It's written in VueJS as frontend and .NET 6 Mini API as Frontend (especially used it for SignalR)

## Current Status
- [x] Show Bingo Board  
- [x] Save Bingo Boards (currently as JSON File, but will be a database soon!)
- [x] Send every click on field to other users
- [ ] Let people create boards
- [ ] Account or secret System to let only the creator edit Boards

## How to build and host
You need to add the file **domain.json** in **frontend/src/assets/** with content: 
```json
{
  "url": "your_url_with_port_for_backend"
}
```

After that use in frontend folder: `yarn build` (or npm run build)   
The build is in: frontend/dist  

In backend folder: `dotnet publish -c Release`  

Start the Backend Server with `dotnet run *dll* --urls=http(s)://your_ip_or_domain:your_port`.  
The frontend build should be located on your Webserver.  

An example boards.json exists in backend folder.
