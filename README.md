SniffSniff -- VkNet bot collection
============= 

A small set of baseline VkNet & ASP.NET based vk-bots.

On the basis of bots located here, you can create cool things!

All bots
--------

### Fully tamed

### In process
-  Echobot

### Wild and uncharted
- Post finder
- Group finder
- **Bidg and Scary DataScience Bot**

How to set the bot up
-------

### After server deployment and start

After bot had been deployed, it will need to get authorization credentials.

**First of all**, you have to pass a GET request to set up such authentication parameters as:
* VK Application id (**ID**)
* VK Application Security Key (**SECURE**)
* VK Group Callback API Confirmation response (**CONFIRMATION**)
* VK Group Callback API Secret (**SECRET**)
* VK Group API Token (**TOKEN**)

So, your _first_ request to the bot will look like this:
```
ADDRESS/control/authapp?id=ID&secure=SECURE&confirmation=CONFIRMATION&secret=SECRET&token=TOKEN
```

where the **ADDRESS** is url link to server running the bot.

After that you will need to authorize VK Application to get the token. You can do that with following GET request:
```
https://oauth.vk.com/authorize?client_id=ID&display=page&redirect_uri=ADDRESS/api/admintoken&scope=offline&response_type=code&v=5.107
```

If all is OK, you will see followind lines in server output:
```
::==>:: Authentication set.
::==>:: App authorized.
```

In general case after theese manipulations you are able to send messages to the echo-bot.

Enjoy!

### Save Authentication across restarts

For the sake of safe storage of all tokens, keys and secrets, they are stored in a static class, but not on the server disk.
This leads to the fact that you have to complete the authorization steps each time you restart the server.

To avoid this, you can save tokens and keys to disk. Upon restart, the save will load automatically.

To save current Authentication tokens, keys and secrets, just make following GET request:
```
ADDRESS/control/saveauth?epoch=CURRENT_EPOCH
```

### General Commands and APIs

**control** section is for server settings and server-side actions.
_Any_ usage of this section must have additional GET parameter -- **epoch=CURRENT_EPOCH**

**api** section is for public usage. You don`t have to pass any secret keys.

#### Control

First thing you have to keep in mind -- the _Epoch_.
Since all APIs are essentially publicly available, the _Epoch_ is a secret that gives access to all application settings.
The _Epoch_ is randomly generated each time you change or read the configuration from the server disk (if it was saved).

When you make a GET request to a server control API, you have to pass an **epoch** GET parameter. If passed value is not equal with value stored in server memory, you will receive HTTP400(Invalid epoch!) page.

The way you can get current __Epoch__ is descibed below:

---

GET **control/getepoch** -- get current Auth Epoch

No parameters. See Epoch value in server output log:
```
::==>:: Current Epoch: _value_
```

---

GET **control/authapp** -- authorize vk app and group
- **id**: VK App ID
- **secure**: VK App securoty key
- **confirmation**: VK Group Callback confirmation
- **secret**: VK Group Callback secret
- **token**: VK Group API token
- **epoch**: Current Auth Epoch

---

GET **control/saveauth** -- save Auth credentials on server disk
- **epoch**: Current Auth Epoch 

#### API

---

POST **api/callback** -- make Callback request (for Callback bots)

This API have to be used by VK Group itself. POST body must be a valid JSON request from VK.

In general case, if VK performs it by itself, and valid **secret** is passed, all might be OK.

---

GET **api/admintoken** -- set VK Application access_token
- **code**: VK Auth code

This API is not for users, but is is completely safe because of VK OAuth redirection.
You have to use this only if you have valid VK Auth **code**