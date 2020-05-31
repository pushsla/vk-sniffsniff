Echobot
==========

Bot for VK group will echo all text messages

Requirements
-------------

- [x] **Framework:** netcoreapp3.1
- [x] **SDK:** Microsoft.NET.Sdk.Web
- [x] **External Libraries:** 
    - [x] VkNet 1.52.0
- [x] **Additionals:**
    - [x] "sniff" project from current solution

Pre-settings
-----------
- Machine with "white" IP, that can receive GET and POST requests (deployment server)
- VK "server" application
- VK group with API token and Callback API setup:
    - API version 5.107
    - Secret key have to be set
    - Callback requests on:
        - [x] Incoming message
        - [ ] Outcoming message
        - [ ] Message editing
        - [ ] Access on receive
        - [ ] Deny on receive
        - [ ] Status changes