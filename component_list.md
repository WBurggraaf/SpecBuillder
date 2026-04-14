# Component List

Generated from per-row symbol classification.

## Component: Controller / API / Interface
- Category: functional
- Assigned symbols: 5

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_HandleServerBans | Class_HandleServerBans | 79 | 93 | Handles server ban requests from clients, likely managing ban logic and response generation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Client_Mode | Client_Mode | 131 | 374 | Handles client connection state transitions and request/response processing for the IRC mode. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Validate_Command | Validate_Command | 366 | 374 | Validates incoming command requests and manages connection state for the command handler. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Handle_Numeric | Handle_Numeric | 417 | 490 | Handles incoming numeric request data from the client to validate and process input parameters. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Handle_Request | Handle_Request | 492 | 573 | Handles incoming network requests and manages the request lifecycle. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_HandleServerBans | Class_HandleServerBans | 79 | 93 |  |  |  | GLOBAL bool Class_HandleServerBans(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Client_Mode | Client_Mode | 131 | 374 |  |  |  | static bool Client_Mode( CLIENT *Client, REQUEST *Req, CLIENT *Origin, CLIENT *Target )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Validate_Command | Validate_Command | 366 | 374 |  |  |  | static bool Validate_Command( UNUSED CONN_ID Idx, UNUSED REQUEST *Req, bool *Closed )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Handle_Numeric | Handle_Numeric | 417 | 490 |  |  |  | static bool Handle_Numeric(CLIENT *client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Handle_Request | Handle_Request | 492 | 573 |  |  |  | static bool Handle_Request( CONN_ID Idx, REQUEST *Req )
```

## Component: Domain Models
- Category: functional
- Assigned symbols: 434

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | addrinfo | addrinfo | 29 | 29 | Defines the data structure for network address information, specifically the addrinfo struct used for resolving hostnames and IP addresses. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | addrinfo | addrinfo | 30 | 30 | Defines the data structure for network address information, specifically the addrinfo struct used for resolving hostnames and IP addresses. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | sockaddr | sockaddr | 151 | 151 | Defines the sockaddr data structure used for network address representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | sockaddr | sockaddr | 151 | 151 | Defines the sockaddr data structure used for network address representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | union | <anonymous> | <anonymous> | 35 | 39 | Defines the union type representing network address structures (socket addresses) used for IP address handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | typedef | ng_ipaddr_t | ng_ipaddr_t | 35 | 39 | Defines the data structure for network address information, including socket address and IPv4/IPv6 address components. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sa | sa | 36 | 36 | Defines the data structure for the socket address (sa) used in network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr | sockaddr | 36 | 36 | Defines the sockaddr data structure used for network address representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sin4 | sin4 | 37 | 37 | Defines the data structure for the IPv4 address socket address, including its fields and type. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr_in | sockaddr_in | 37 | 37 | Defines the data structure for network address information, specifically the sockaddr_in struct used to represent socket address objects. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sin6 | sin6 | 38 | 38 | Defines the data structure for the IPv6 address socket address. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr_in6 | sockaddr_in6 | 38 | 38 | Declares the sockaddr_in6 structure, defining the layout and fields of the IPv6 address data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | NG_IP_ADDR_DONTUSE | NG_IP_ADDR_DONTUSE | 42 | 44 | Defines the data structure for an IP address that is not used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sin4 | NG_IP_ADDR_DONTUSE::sin4 | 43 | 43 | Defines the data structure for the IP address field, specifically the sockaddr_in struct. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr_in | NG_IP_ADDR_DONTUSE::sockaddr_in | 43 | 43 | Defines the data structure for network address information, specifically a sockaddr_in variant used by the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | NG_IP_ADDR_DONTUSE | NG_IP_ADDR_DONTUSE | 45 | 45 | Defines a data structure for non-usable IP address objects. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | typedef | ng_ipaddr_t | ng_ipaddr_t | 45 | 45 | Defines the data structure and type for network IP address objects. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_length | array_length | 91 | 102 | Defines the data structure and interface for the array type used to store chat channel information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_start | array_start | 271 | 276 | Defines the structure and layout of the array data type used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | struct | <anonymous> | <anonymous> | 22 | 26 | Defines the struct type for storing allocated memory and usage statistics. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | typedef | array | array | 22 | 26 | Defines the data structure for the array type used to store allocated memory and usage statistics. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | field | mem | mem | 23 | 23 | Declares a scalar data structure for storing memory addresses within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | field | allocated | allocated | 24 | 24 | Defines the data structure and type for the allocated field within the ngIRCd array. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | field | used | used | 25 | 25 | Defines the data structure and type for the 'used' field within the ngIRCd array. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetListBans | Channel_GetListBans | 67 | 72 | Defines the data structure for retrieving banned channels from the channel list. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetListExcepts | Channel_GetListExcepts | 75 | 80 | Defines the data structure for channel lists, specifically the list_head pointer type used to represent the collection of channels. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetListInvites | Channel_GetListInvites | 83 | 88 | Defines the data structure for a channel's invite list, including the pointer to the linked list head. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | Conf_Channel | Conf_Channel | 99 | 99 | Defines the data structure for a channel configuration object used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Free_Channel | Free_Channel | 205 | 215 | Defines the structure and lifecycle of the Channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Part | Channel_Part | 293 | 325 | Defines the structure and logic for channel-related data, including parameters for channel participation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CountVisible | Channel_CountVisible | 453 | 470 | Defines the data structure for channel visibility counts within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_MemberCount | Channel_MemberCount | 473 | 488 | Defines the data structure for channel members, including the count of members within a channel. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CountForUser | Channel_CountForUser | 491 | 509 | Defines the data structure for tracking the number of channels associated with a specific client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Name | Channel_Name | 512 | 517 | Defines the data structure for a channel name within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Modes | Channel_Modes | 520 | 525 | Defines the data structure and interface for channel modes within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_HasMode | Channel_HasMode | 528 | 533 | Defines the data structure and interface for the Channel entity, including its mode attribute. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Key | Channel_Key | 536 | 541 | Defines the data structure for a channel key within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_MaxUsers | Channel_MaxUsers | 544 | 549 | Defines the data structure and constraints for the maximum number of users allowed per channel. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_First | Channel_First | 552 | 556 | Defines the data structure for a channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Next | Channel_Next | 559 | 564 | Defines the data structure and lifecycle for a channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Search | Channel_Search | 567 | 589 | Defines the data structure for a global channel entity used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_FirstMember | Channel_FirstMember | 592 | 597 | Defines the data structure for channel membership information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_NextMember | Channel_NextMember | 600 | 606 | Defines the data structure for channel membership and the conversion logic between channel and channel list representations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_FirstChannelOf | Channel_FirstChannelOf | 609 | 614 | Defines the data structure for a channel's first channel, representing the core entity within the IRC server's network topology. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetChannel | Channel_GetChannel | 634 | 639 | Defines the data structure for a global channel object used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_IsValidName | Channel_IsValidName | 642 | 657 | Validates the name of an IRC channel against a defined set of valid characters and formats. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ModeAdd | Channel_ModeAdd | 660 | 680 | Defines the data structure for channel modes within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ModeDel | Channel_ModeDel | 683 | 704 | Defines the data structure and interface for channel modes within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserModeDel | Channel_UserModeDel | 735 | 762 | Defines the data structure for channel user mode delimiters within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserModes | Channel_UserModes | 765 | 779 | Defines the data structure for channel user modes within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserHasMode | Channel_UserHasMode | 790 | 804 | Defines the data structure and interface for channel user mode checking logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_IsMemberOf | Channel_IsMemberOf | 807 | 815 | Defines the data structure and interface for channel membership state within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Topic | Channel_Topic | 818 | 825 | Defines the data structure for a channel topic within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_TopicTime | Channel_TopicTime | 830 | 835 | Defines the data structure and type for the Channel Topic Time field within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_TopicWho | Channel_TopicWho | 838 | 843 | Defines the data structure for channel topics and the logic to retrieve the topic owner. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CreationTime | Channel_CreationTime | 846 | 851 | Defines the data structure and lifecycle state for an IRC channel entity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetTopic | Channel_SetTopic | 856 | 881 | Defines the data structure and interface for a chat channel entity within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetModes | Channel_SetModes | 884 | 891 | Defines the data structure and interface for channel state and mode configuration within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetKey | Channel_SetKey | 894 | 902 | Defines the data structure and type for the IRC channel entity used in the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetMaxUsers | Channel_SetMaxUsers | 905 | 912 | Defines the data structure for managing the maximum number of users in a channel. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Create | Channel_Create | 997 | 1021 | Defines the data structure for a global channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Get_Cl2Chan | Get_Cl2Chan | 1024 | 1039 | Defines the CL2CHAN structure and CHANNEL type used to represent channel state and client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Add_Client | Add_Client | 1042 | 1068 | Defines the data structures and types used to represent IRC channel and client entities within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_AddBan | Channel_AddBan | 1161 | 1167 | Defines the data structure and interface for channel ban operations within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1164 | 1164 | Represents a data structure for channel state information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1173 | 1173 | Defines the data structure for an IRC channel, including its linked list representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_AddInvite | Channel_AddInvite | 1179 | 1185 | Defines the data structure and interface for channel invite management within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1182 | 1182 | Represents a data structure for channel state information within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1189 | 1189 | Represents a data structure for channel state information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_elem | list_elem | 1192 | 1192 | Defines the data structure for channel elements within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ShowBans | Channel_ShowBans | 1213 | 1223 | Defines the data structures and types for channel ban information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1216 | 1216 | Represents a data structure for channel state information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ShowExcepts | Channel_ShowExcepts | 1226 | 1236 | Defines the data structure and interface for the Channel entity used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1229 | 1229 | Represents a data structure for channel state information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ShowInvites | Channel_ShowInvites | 1239 | 1249 | Defines the data structures and types for channel invites within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1242 | 1242 | Represents a data structure used to store channel information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CheckKey | Channel_CheckKey | 1272 | 1319 | Defines the data structure and interface for the Channel entity used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Get_First_Cl2Chan | Get_First_Cl2Chan | 1322 | 1326 | Defines the CL2CHAN structure used to represent channel state information within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Get_Next_Cl2Chan | Get_Next_Cl2Chan | 1329 | 1344 | Defines the CL2CHAN structure, a data structure representing a channel in the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Delete_Channel | Delete_Channel | 1350 | 1376 | Defines the CHANNEL data structure used to represent channel state and channel deletion logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CHANNEL | _CHANNEL | 26 | 44 | Defines the data structure and fields for the channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CHANNEL | CHANNEL | 26 | 44 | Defines the data structure for a channel entity, including its name, hash, modes, topic, and creation time. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | _CHANNEL | _CHANNEL::_CHANNEL | 28 | 28 | Defines the data structure and fields for the channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CHANNEL | _CHANNEL::_CHANNEL | 28 | 28 | Defines the data structure and layout for the channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | name | _CHANNEL::name | 29 | 29 | Defines the data structure and type for the channel entity within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | hash | _CHANNEL::hash | 30 | 30 | Defines the data structure and type for the channel entity within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | modes | _CHANNEL::modes | 31 | 31 | Defines the data structure and type for channel modes within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | topic | _CHANNEL::topic | 32 | 32 | Defines the data structure for channel topics within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | creation_time | _CHANNEL::creation_time | 34 | 34 | Defines the data structure and type for the channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | topic_time | _CHANNEL::topic_time | 35 | 35 | Defines the data structure and type for the channel topic time field within the ngIRCd channel entity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | topic_who | _CHANNEL::topic_who | 36 | 36 | Defines the data structure for channel topics, including the field name, type, and size constraints. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | key | _CHANNEL::key | 38 | 38 | Defines the data structure and type for the channel entity within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | maxusers | _CHANNEL::maxusers | 39 | 39 | Defines the data structure and type for the channel entity, including its maximum user count. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | list_bans | _CHANNEL::list_bans | 40 | 40 | Defines the data structure for channel bans within the IRC server's domain model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | list_head | _CHANNEL::list_head | 40 | 40 | Defines the data structure for an IRC channel entity within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | list_excepts | _CHANNEL::list_excepts | 41 | 41 | Defines the data structure for channel exceptions within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | list_head | _CHANNEL::list_head | 41 | 41 | Defines the data structure for an IRC channel entity within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | list_head | _CHANNEL::list_head | 42 | 42 | Defines the data structure for an IRC channel entity within the server's internal model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | list_invites | _CHANNEL::list_invites | 42 | 42 | Defines the data structure for the channel list, including the linked list node type used to store the list. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | keyfile | _CHANNEL::keyfile | 43 | 43 | Defines the data structure and type for the channel keyfile field within the ngIRCd channel entity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CLIENT2CHAN | _CLIENT2CHAN | 46 | 52 | Defines the data structure for a client-channel relationship, including pointers to the client, channel, and mode configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CL2CHAN | CL2CHAN | 46 | 52 | Defines a data structure representing a client-to-channel mapping with pointers to client, channel, and mode arrays. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | _CLIENT2CHAN | _CLIENT2CHAN::_CLIENT2CHAN | 48 | 48 | Defines the data structure for a channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CLIENT2CHAN | _CLIENT2CHAN::_CLIENT2CHAN | 48 | 48 | Defines the data structure for a client-to-channel mapping, representing the state of an IRC channel connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | CLIENT | _CLIENT2CHAN::CLIENT | 49 | 49 | Declares the data structure for the CLIENT channel state, defining its type and ownership. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | CHANNEL | _CLIENT2CHAN::CHANNEL | 50 | 50 | Defines the data structure and type for the channel entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | modes | _CLIENT2CHAN::modes | 51 | 51 | Defines the data structure for channel modes within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CHANNEL | CHANNEL | 56 | 56 | Defines the data structure for an IRC channel entity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CL2CHAN | CL2CHAN | 57 | 57 | Defines a typedef for a pointer to a channel structure, representing a core data entity within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | struct | list_head | list_head | 28 | 28 | Represents a data structure or object definition, specifically a linked list node type used for internal data organization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_AddMask | Class_AddMask | 96 | 109 | Defines the structure and behavior of the Class_AddMask function, representing a specific domain entity or data structure within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_DeleteMask | Class_DeleteMask | 111 | 121 | Defines the structure and behavior of the Class_DeleteMask data structure used for pattern matching. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_GetList | Class_GetList | 123 | 129 | Defines the data structure and type for the Class enumeration used in the server's configuration or internal state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_Expire | Class_Expire | 131 | 136 | A function that likely manages the lifecycle or expiration state of a specific class entity within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_Cap | Client_Cap | 28 | 34 | Defines the data structure and interface for the client capability information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_CapSet | Client_CapSet | 36 | 45 | Defines the structure and capabilities of the Client entity within the ngIRCd application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | struct | hostent | hostent | 74 | 74 | Defines the structure of the hostent data structure used for network host information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Init_New_Client | Init_New_Client | 179 | 224 | Defines the structure and type of the client object being initialized. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetOrigUser | Client_SetOrigUser | 428 | 437 | Defines the structure and type of the client object used for user identification and configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetAccountName | Client_SetAccountName | 475 | 488 | Defines the structure and type of the client object used to manage user account information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Type | Client_Type | 680 | 685 | Defines the data structure and type for the client object used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ID | Client_ID | 696 | 706 | Defines the structure and type of the Client_ID data object used within the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Info | Client_Info | 709 | 714 | Defines the structure and data representation for the client connection information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_OrigUser | Client_OrigUser | 734 | 737 | Defines the structure and type of the original user client object used in the application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_UpdateCloakedHostname | Client_UpdateCloakedHostname | 815 | 852 | Defines the structure and type of the Client object used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Modes | Client_Modes | 854 | 859 | Defines the data structures and enums for client connection modes used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Flags | Client_Flags | 862 | 867 | Defines the structure and flags for the client connection state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HasMode | Client_HasMode | 979 | 984 | Defines the data structure and interface for the client state, specifically checking for supported modes. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HasFlag | Client_HasFlag | 987 | 992 | Defines the data structure and flags associated with the client object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_AccountName | Client_AccountName | 1003 | 1008 | Defines the data structure for the client's account name, representing a core business entity within the application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_CheckNick | Client_CheckNick | 1021 | 1056 | Defines the structure and type of the client object used for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_UserCount | Client_UserCount | 1110 | 1114 | Defines the data structure for tracking the number of connected users in the client session. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ServiceCount | Client_ServiceCount | 1117 | 1121 | Defines the data structure and lifecycle state for the client service count metric. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyUserCount | Client_MyUserCount | 1131 | 1135 | Defines the data structure for tracking the count of users in the client session. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyServiceCount | Client_MyServiceCount | 1138 | 1142 | A function representing a service count metric, likely part of a data structure or business entity used to track server statistics. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MaxUserCount | Client_MaxUserCount | 1195 | 1199 | Defines the maximum number of users allowed in the client connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyMaxUserCount | Client_MyMaxUserCount | 1202 | 1206 | Defines the maximum user count limit for the client application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_IsValidNick | Client_IsValidNick | 1215 | 1238 | Validates the validity of an IRC nickname against server rules. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_GetLastWhowasIndex | Client_GetLastWhowasIndex | 1253 | 1257 | Defines the data structure and state for tracking user presence history within the IRC client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Introduce | Client_Introduce | 1313 | 1345 | Defines the structure and interface for the Client entity used in the chat server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Count | Count | 1348 | 1361 | Defines the structure and type of the CLIENT_TYPE enum used to represent client connection states. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | MyCount | MyCount | 1364 | 1377 | Defines the client type enum and the MyCount function signature used to represent client state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | New_Client_Struct | New_Client_Struct | 1385 | 1406 | Defines the structure and type of the client object used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_TypeText | Client_TypeText | 1518 | 1535 | Defines the structure and type of the client object used in the application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _CLIENT | _CLIENT | 41 | 66 | Defines the data structure and fields for the client entity used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | typedef | CLIENT | CLIENT | 41 | 66 | Defines the data structure and fields for the CLIENT entity used in the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | starttime | _CLIENT::starttime | 43 | 43 | Defines the data structure and type for the client object, including its lifecycle state and timestamp. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | id | _CLIENT::id | 44 | 44 | Defines the data structure and type for the client object within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | hash | _CLIENT::hash | 45 | 45 | Defines the data structure and type for the _CLIENT object, including its hash field. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | POINTER | _CLIENT::POINTER | 46 | 46 | Defines the data structure and pointer relationships for the client object within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | type | _CLIENT::type | 47 | 47 | Defines the data structure and type for the client object within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | conn_id | _CLIENT::conn_id | 48 | 48 | Defines the data structure and type for the client connection identifier. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | _CLIENT | _CLIENT::_CLIENT | 49 | 49 | Defines the data structure and shape of the client object used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _CLIENT | _CLIENT::_CLIENT | 49 | 49 | Defines the data structure and layout for the client object used by the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | _CLIENT | _CLIENT::_CLIENT | 50 | 50 | Defines the data structure and fields for the client object used in the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _CLIENT | _CLIENT::_CLIENT | 50 | 50 | Defines the data structure and layout for the client object used by the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | host | _CLIENT::host | 51 | 51 | Defines the data structure and type for the client host field within the ngIRCd client class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | cloaked | _CLIENT::cloaked | 52 | 52 | Declares a scalar field representing a client's cloaked status within the ngIRCd client structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | ipa_text | _CLIENT::ipa_text | 53 | 53 | Declares the data structure and type for the ipa_text field within the _CLIENT class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | user | _CLIENT::user | 54 | 54 | Defines the data structure and type for the client user field within the ngIRCd client class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | orig_user | _CLIENT::orig_user | 56 | 56 | Defines the data structure and type for the original user identifier within the client context. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | info | _CLIENT::info | 59 | 59 | Defines the data structure and shape for the CLIENT object within the ngIRCd application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | modes | _CLIENT::modes | 60 | 60 | Defines the data structure and type for the client's mode configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | hops | _CLIENT::hops | 61 | 61 | Defines the data structure and type for the client connection state, including hop count and associated tokens. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | away | _CLIENT::away | 62 | 62 | Declares the `away` field as a scalar property within the `_CLIENT` domain model structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | flags | _CLIENT::flags | 63 | 63 | Defines the data structure and flags for the client object within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | account_name | _CLIENT::account_name | 64 | 64 | Defines the data structure and type for the client account name field within the ngIRCd client class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | capabilities | _CLIENT::capabilities | 65 | 65 | Defines the data structure and type for the client's capabilities field within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | typedef | CLIENT | CLIENT | 70 | 70 | Defines the CLIENT data structure used to represent client connections within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _WHOWAS | _WHOWAS | 75 | 83 | Defines the data structure for client connection information including timestamp, nickname, host, user, and server details. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | typedef | WHOWAS | WHOWAS | 75 | 83 | Defines the data structure for a WHOWAS entry, representing client identity and connection details. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | time | _WHOWAS::time | 77 | 77 | Defines the data structure and type for the 'time' field within the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | id | _WHOWAS::id | 78 | 78 | Defines the data structure and type for the client nickname identifier. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | host | _WHOWAS::host | 79 | 79 | Defines the data structure and shape for the host field within the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | user | _WHOWAS::user | 80 | 80 | Defines the data structure and type for the user entity within the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | info | _WHOWAS::info | 81 | 81 | Defines the structure and data layout for the _WHOWAS client information object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | server | _WHOWAS::server | 82 | 82 | Defines the server host name structure used by the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | struct | ConnSSL_State | ConnSSL_State | 35 | 46 | Defines the data structure and state representation for SSL connection management. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | SSL | ConnSSL_State::SSL | 37 | 37 | Defines the data structure and type for the SSL connection state object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | gnutls_session | ConnSSL_State::gnutls_session | 40 | 40 | Defines the data structure and type for the SSL connection state, representing the internal state of the connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | cookie | ConnSSL_State::cookie | 41 | 41 | Defines the data structure and state for SSL connection handling within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | x509_cred_idx | ConnSSL_State::x509_cred_idx | 43 | 43 | Defines the data structure and state for SSL connection credentials within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | fingerprint | ConnSSL_State::fingerprint | 45 | 45 | Defines the data structure and state representation for the SSL connection fingerprint within the ConnSSL_State class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | passwd | passwd | 340 | 340 | Defines the `struct passwd` data structure used to store user authentication credentials. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | group | group | 341 | 341 | Defines the structure and fields of the 'group' data structure used to store server configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 345 | 345 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | dirent | dirent | 922 | 922 | Defines the structure of the configuration file, representing the directory entry used to store server settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 1171 | 1172 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 1175 | 1175 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | passwd | passwd | 1346 | 1346 | Defines the structure and fields of the passwd system user data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | group | group | 1347 | 1347 | Defines the structure and layout of the 'group' data structure used to store configuration settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 2025 | 2025 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 2053 | 2053 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | hostent | hostent | 2140 | 2140 | Defines the structure and fields of the hostent data structure used for network host information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | rlimit | rlimit | 2144 | 2144 | Defines the structure and type of the rlimit configuration struct used by the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 2289 | 2289 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | Conf_Oper | Conf_Oper | 36 | 40 | Defines the data structure for configuration operations, including name, password, and host mask fields. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | typedef | CONF_SERVER | CONF_SERVER | 47 | 68 | Defines the data structure for a server configuration object, including host, client ID, password, and port. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | name | _Conf_Server::name | 50 | 50 | Defines the structure and data shape of the server configuration, including the server name field. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | pwd_out | _Conf_Server::pwd_out | 52 | 52 | Defines the data structure and type for the server's password output field within the configuration hierarchy. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | lasttry | _Conf_Server::lasttry | 55 | 55 | Defines the data structure and type for the server's configuration server state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | res_stat | _Conf_Server::res_stat | 56 | 56 | Defines the data structure and type for the server's configuration state, specifically representing the process status. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | conn_id | _Conf_Server::conn_id | 58 | 58 | Defines the data structure and type for the server's connection identifier. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | ng_ipaddr_t | _Conf_Server::ng_ipaddr_t | 61 | 61 | Defines the data structure and type for server IP address configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | svs_mask | _Conf_Server::svs_mask | 66 | 66 | Defines the data structure and type for the server's configuration server object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | Conf_Channel | Conf_Channel | 87 | 96 | Defines the data structures and fields for the channel configuration object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | name | Conf_Channel::name | 88 | 88 | Defines the data structure and type for the Conf_Channel entity used by the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | modes | Conf_Channel::modes | 89 | 89 | Defines the data structure and type for the Conf_Channel channel mode configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | topic | Conf_Channel::topic | 91 | 91 | Defines the data structure and type for the Conf_Channel topic field within the ngIRCd configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | maxusers | Conf_Channel::maxusers | 94 | 94 | Defines the data structure and type for the maximum number of users allowed in a channel. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | struct | <anonymous> | <anonymous> | 69 | 73 | Defines the structure of SSL certificate credentials and Diffie-Hellman parameters used for secure connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | typedef | x509_cred_slot | x509_cred_slot | 69 | 73 | Defines a data structure for storing X.509 certificate credentials and associated DH parameters. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | field | x509_cred | x509_cred | 71 | 71 | Defines the data structure for SSL certificate credentials using the gnutls library. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | field | dh_params | dh_params | 72 | 72 | Declares a data structure for Diffie-Hellman parameters used in SSL/TLS authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | struct | stat | stat | 94 | 94 | Defines the structure and layout of the `struct stat` used to represent file system status information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | timeval | timeval | 671 | 671 | Defines the structure and layout of the timeval data type used for network time synchronization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | request_info | request_info | 1369 | 1369 | Defines the data structure for an IRC request information object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | typedef | CONN_ID | CONN_ID | 46 | 46 | Defines the data structure and type for connection identifiers used in the server's networking layer. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | typedef | ZIPDATA | ZIPDATA | 64 | 71 | Defines a data structure for storing compressed data streams and associated buffer statistics. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | rbuf | _ZipData::rbuf | 68 | 68 | Defines the data structure and storage layout for the ZipData object within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | struct | _Connection | _Connection | 74 | 107 | Defines the data structure for an IRC connection, including socket handle, IP address, hostname, and buffer pointers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | typedef | CONNECTION | CONNECTION | 74 | 107 | Defines the data structure for the connection object, including socket handle, IP address, process status, hostname, password, and buffer arrays. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | sock | _Connection::sock | 76 | 76 | Declares the `sock` field as a scalar integer property within the `_Connection` class structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | addr | _Connection::addr | 77 | 77 | Declares the data structure for the connection address within the IRC daemon's internal model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | proc_stat | _Connection::proc_stat | 78 | 78 | Defines the data structure and state for a network connection object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | host | _Connection::host | 79 | 79 | Defines the data structure for the host field within the _Connection class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | pwd | _Connection::pwd | 80 | 80 | Declares the `pwd` field as a scalar character pointer within the `_Connection` data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | rbuf | _Connection::rbuf | 81 | 81 | Defines the data structure and storage layout for the connection object within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | wbuf | _Connection::wbuf | 82 | 82 | Declares the internal data structure and storage layout for the connection object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | signon | _Connection::signon | 83 | 83 | Declares the `signon` field as a scalar type within the `_Connection` data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | lastdata | _Connection::lastdata | 84 | 84 | Declares a scalar field representing the last data timestamp within the _Connection structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | lastping | _Connection::lastping | 85 | 85 | Declares the `lastping` field as a `time_t` scalar within the `_Connection` data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | lastprivmsg | _Connection::lastprivmsg | 86 | 86 | Declares a data structure representing the last private message timestamp within the IRC connection state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | delaytime | _Connection::delaytime | 87 | 87 | Declares a scalar field representing the delaytime property within the _Connection data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | bytes_in | _Connection::bytes_in | 88 | 88 | Defines the data structure and fields for the _Connection object used to track network connection metrics. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | msg_in | _Connection::msg_in | 89 | 89 | Declares the data structure for incoming network messages within the connection class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | flag | _Connection::flag | 90 | 90 | Defines the data structure and properties for the _Connection object used in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | options | _Connection::options | 91 | 91 | Defines the data structure and type for the _Connection object, including its options field. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | bps | _Connection::bps | 92 | 92 | Defines the data structure and type for the connection object, including its bandwidth property. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | CLIENT | _Connection::CLIENT | 93 | 93 | Defines the data structure and type for the CLIENT connection state within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | struct | ConnSSL_State | _Connection::ConnSSL_State | 98 | 98 | Defines the internal state structure for SSL connections within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | ssl_state | _Connection::ssl_state | 98 | 98 | Defines the data structure and state representation for the SSL connection within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | auth_ping | _Connection::auth_ping | 101 | 101 | Defines the data structure and type for the authentication ping field within the connection object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | iconv_from | _Connection::iconv_from | 104 | 104 | Defines the data structure and type for the iconv_from field within the _Connection class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | iconv_to | _Connection::iconv_to | 105 | 105 | Defines the data structure and type for the iconv_to field within the _Connection class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | <anonymous> | <anonymous> | 34 | 41 | Defines the internal data structure for the 'what' field within the ngIRCd io.c file. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | typedef | io_event | io_event | 34 | 41 | Defines a data structure representing an IRC event with a callback and a field. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | field | what | what | 40 | 40 | Defines the data structure and shape for the 'what' field within the ngIRCd source code. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 79 | 79 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 88 | 88 | Defines the structure and layout of the timeval data type used for network time synchronization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 136 | 136 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 176 | 176 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | dvpoll | dvpoll | 178 | 178 | Defines the data structure and shape of the dvpoll object used to manage virtual device polling state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 182 | 182 | Represents the structure of a pollfd struct, defining its fields and layout. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 230 | 230 | Defines the structure and layout of the pollfd data type used for managing network I/O events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 257 | 257 | Defines the structure and layout of the timeval data type used for network time synchronization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 263 | 263 | Represents the structure of a pollfd struct, defining its fields and layout. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 299 | 299 | Represents the structure of the pollfd data type, defining its fields and layout. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 320 | 320 | Represents the structure of the pollfd data type, defining its fields and layout. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 338 | 338 | Defines the structure and layout of the pollfd data type used for managing network I/O events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 343 | 343 | Defines the structure and layout of the pollfd data type used for managing network I/O events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 365 | 365 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 474 | 474 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 532 | 532 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 534 | 534 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 559 | 559 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 582 | 582 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 585 | 585 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 586 | 586 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timespec | timespec | 587 | 587 | Defines the structure and layout of the timespec data type used for tracking time intervals in the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 592 | 592 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 829 | 829 | Defines the kevent structure, a data structure used to manage event notifications within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 892 | 892 | Defines the structure and layout of the timeval data type used for network time synchronization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.h | struct | timeval | timeval | 53 | 53 | Defines the structure and layout of the timeval data type used for time synchronization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | join_allowed | join_allowed | 77 | 144 | Defines the structure and validation logic for IRC channel join requests. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | join_set_channelmodes | join_set_channelmodes | 153 | 168 | Defines the structure and behavior of the IRC channel entity within the server's data model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_TOPIC | IRC_TOPIC | 476 | 569 | Defines the data structure and interface for handling IRC channel topics within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_CHANINFO | IRC_CHANINFO | 664 | 763 | Defines the data structure and interface for channel information within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHO_Channel | IRC_WHO_Channel | 138 | 194 | Defines the data structures and types for IRC channel information, including the channel object and client context. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHO_Mask | IRC_WHO_Mask | 204 | 284 | Defines the structure and behavior of the IRC WHO mask data type used for client identification. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | WHOWAS_EntryWrite | WHOWAS_EntryWrite | 440 | 454 | Defines the structure and behavior of the WHOWAS Entry data object used for IRC message history. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_INFO | IRC_INFO | 539 | 585 | Defines the structure and interface for the IRC client and request objects used in the server's networking logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_LUSERS | IRC_LUSERS | 685 | 705 | Defines the data structure and interface for the IRC user list, representing the core entity used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_MOTD | IRC_MOTD | 749 | 768 | Defines the structure and behavior of the IRC MOTD (Message of the Day) data object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_NAMES | IRC_NAMES | 777 | 846 | Defines the data structures and constants for IRC client and request objects used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_STATS | IRC_STATS | 855 | 976 | Defines the structure and interface for IRC statistics data used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | struct | list_head | list_head | 864 | 864 | Represents a data structure or object definition used to model the server's internal state and configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | struct | list_elem | list_elem | 865 | 865 | Defines the data structure and layout for the list element used to store chat channel information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_TIME | IRC_TIME | 1001 | 1025 | Defines the structure and type of the IRC_TIME data structure used within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_USERHOST | IRC_USERHOST | 1034 | 1071 | Defines the data structure and interface for IRC user host information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_USERS | IRC_USERS | 1080 | 1087 | Defines the data structure and interface for the IRC_USERS client information entity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_VERSION | IRC_VERSION | 1096 | 1128 | Defines the global IRC version constant used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_USER | IRC_USER | 420 | 518 | Defines the structure and interface for the IRC user entity within the server's data model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | Change_Nick | Change_Nick | 901 | 931 | Defines the structure and behavior of the client connection state and nickname change logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-metadata.c | function | IRC_METADATA | IRC_METADATA | 42 | 110 | Defines the structure and interface for IRC metadata data structures used by the client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | IRC_MODE | IRC_MODE | 60 | 100 | Defines the data structure and state for the IRC mode configuration and client request handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Mode_Limit_Reached | Mode_Limit_Reached | 111 | 120 | Defines the internal state and limits for an IRC client session, including the maximum number of clients allowed before a limit is reached. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Channel_Mode_Answer_Request | Channel_Mode_Answer_Request | 383 | 433 | Defines the data structures and types for IRC channel state and mode responses. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Channel_Mode | Channel_Mode | 444 | 977 | Defines the data structure and interface for channel state and mode within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | IRC_AWAY | IRC_AWAY | 986 | 1006 | Defines the data structure and interface for the IRC_AWAY command, representing the state of a client's departure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Add_To_List | Add_To_List | 1018 | 1072 | Defines the data structures and types used to represent IRC channel and client information within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | struct | list_head | list_head | 1023 | 1023 | Represents a data structure or object definition used to model the state of the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | struct | list_head | list_head | 1089 | 1089 | Represents a data structure or object definition used to model the state of the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_OPER | IRC_OPER | 65 | 101 | Defines the data structure and interface for IRC operation requests and clients within the server's core logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | struct | Conf_Oper | Conf_Oper | 68 | 68 | Defines the structure and fields of the configuration operation object used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | struct | list_head | list_head | 389 | 389 | Represents a data structure or object definition used to model the internal state of the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | IRC_SetPenalty | IRC_SetPenalty | 541 | 557 | Defines the data structure and type for the penalty value within the IRC client communication protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | Get_Prefix | Get_Prefix | 559 | 569 | Defines the structure and type of the client object used in the IRC write operation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_CheckListTooBig | IRC_CheckListTooBig | 59 | 76 | Defines the structure and validation logic for the IRC client list data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_ERROR | IRC_ERROR | 85 | 120 | Defines the structure and behavior of the IRC client and request objects used in the server's core logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 31 | 37 | Defines the data structure for an IRC message list element, including pointers, masks, reasons, validity times, and flags. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | list_elem | list_elem::list_elem | 32 | 32 | Defines the data structure and fields for the list element object used in the server's internal data representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem::list_elem | 32 | 32 | Defines the data structure and layout for the list element object used in the server's internal data representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | mask | list_elem::mask | 33 | 33 | Defines the data structure and type for the mask field within the list_elem domain model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | reason | list_elem::reason | 34 | 34 | Defines the data structure and type for the 'reason' field within the list_elem class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | valid_until | list_elem::valid_until | 35 | 35 | Defines the data structure and type for the `valid_until` field within the `list_elem` domain entity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | onlyonce | list_elem::onlyonce | 36 | 36 | Defines the data structure and type for a list element with a boolean flag indicating uniqueness. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetMask | Lists_GetMask | 45 | 50 | Defines the data structure and type for the list element used in the server's internal data representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 46 | 46 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 59 | 59 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetValidity | Lists_GetValidity | 71 | 76 | Defines the structure and validity rules for list elements within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 72 | 72 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetOnlyOnce | Lists_GetOnlyOnce | 84 | 89 | A function that retrieves a single list element from a global list structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 85 | 85 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetFirst | Lists_GetFirst | 97 | 102 | Defines the data structure for list elements within the server's internal data model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 98 | 98 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetNext | Lists_GetNext | 110 | 115 | Defines the structure and type of the list element data structure used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 111 | 111 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Add | Lists_Add | 126 | 170 | Defines the data structures and types used to represent the server's internal state and message lists. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 127 | 127 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 130 | 130 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 148 | 148 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Unlink | Lists_Unlink | 179 | 194 | Defines the data structures and pointers used to manage the linked list of IRC channel members. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 180 | 180 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 180 | 180 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 180 | 180 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Del | Lists_Del | 202 | 223 | Defines the structure and behavior of the list data structure used for managing IRC channel lists. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 203 | 203 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 205 | 205 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 231 | 231 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 233 | 233 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_CheckDupeMask | Lists_CheckDupeMask | 256 | 267 | Defines the data structure for duplicate list elements within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 257 | 257 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 259 | 259 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Check | Lists_Check | 317 | 321 | Defines the data structures and types used to represent client connections and list state within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 318 | 318 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_CheckReason | Lists_CheckReason | 332 | 360 | Defines the data structure and logic for handling client connection lists and reason codes within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 333 | 333 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 335 | 335 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Expire | Lists_Expire | 367 | 398 | Defines the data structures and lifecycle management for the list expiration tracking system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 368 | 368 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 370 | 370 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Count | Lists_Count | 406 | 420 | Defines the data structure and lifecycle state for the list head node used in the server's internal data model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 407 | 407 | Represents the data structure for a linked list node, defining its type and memory layout. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 409 | 409 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 23 | 23 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 25 | 27 | Defines the data structure for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | field | list_elem | list_head::list_elem | 26 | 26 | Defines the data structure and layout for the list element object used in the server's internal data representation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_head::list_elem | 26 | 26 | Defines the data structure and layout for the list element used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 29 | 29 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 30 | 30 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 32 | 32 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 33 | 33 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 35 | 35 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 38 | 38 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 41 | 41 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 42 | 42 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 44 | 44 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 47 | 47 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 48 | 48 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 49 | 49 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 50 | 50 | Defines the data structure and layout for the list element used to store chat messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 52 | 52 | Defines the data structure and layout for the linked list node used in the server's internal data storage. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | struct | Conf_Channel | Conf_Channel | 223 | 223 | Defines the data structure for a channel configuration, including its fields and properties. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | MatchCaseInsensitiveList | MatchCaseInsensitiveList | 85 | 101 | Defines a data structure for matching patterns against strings, likely used to store and manipulate case-insensitive search results. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | NGIRCd_getNobodyID | NGIRCd_getNobodyID | 573 | 603 | Defines the data structure and type for retrieving the ID of a nobody user in the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | struct | passwd | passwd | 576 | 576 | Represents the passwd structure, a core data structure used for user authentication and identity management. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | struct | passwd | passwd | 659 | 659 | Defines the structure of the passwd user data record used for authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | struct | group | group | 660 | 660 | Defines the `group` data structure used to represent server groups within the ngIRCd application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_head | list_head | 151 | 151 | Defines the data structure and layout for the numeric list node used in the server's internal state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_elem | list_elem | 153 | 153 | Defines the data structure and layout for a list element within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_head | list_head | 177 | 177 | Defines the data structure and layout for the numeric list node used in the server's internal state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_elem | list_elem | 178 | 178 | Defines the data structure and layout for a list element within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | IRC_Num_ENDOFMOTD | IRC_Num_ENDOFMOTD | 258 | 344 | Defines the data structure and logic for the END_OF_MOTD flag within the IRC client protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | IRC_Num_ISUPPORT | IRC_Num_ISUPPORT | 349 | 379 | Defines the data structure and interface for the IRC support list enumeration used by the client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | struct | _NUMERIC | _NUMERIC | 49 | 52 | Defines the data structure for numeric values and associated function signatures used in the server's request parsing logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | field | numeric | _NUMERIC::numeric | 50 | 50 | Defines the data structure and type for the 'numeric' field within the ngIRCd source code. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | field | function | _NUMERIC::function | 51 | 51 | Defines the data structure and type for the _NUMERIC function field within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | field | PARAMS | _NUMERIC::PARAMS | 51 | 51 | Defines the structure and shape of the parsed data fields, including the PARAMS scalar type and its usage in the client request. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | struct | _NUMERIC | _NUMERIC | 420 | 420 | Defines the data structure and type for numeric values within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | struct | _REQUEST | _REQUEST | 23 | 29 | Defines the data structure for an IRC request, including fields for command prefix, command name, and parameter array. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | typedef | REQUEST | REQUEST | 23 | 29 | Defines the data structure for an IRC request message, including fields for prefix, command, and parameters. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | prefix | _REQUEST::prefix | 25 | 25 | Defines the structure and type of the _REQUEST data structure used for parsing command arguments. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | command | _REQUEST::command | 26 | 26 | Defines the structure and type of the command field within the _REQUEST data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | argv | _REQUEST::argv | 27 | 27 | Defines the structure and type of the request data being parsed, including the argv array. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | argc | _REQUEST::argc | 28 | 28 | Defines the structure and type of the request argument passed to the parser. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | struct | _COMMAND | _COMMAND | 32 | 43 | Defines the structure and fields of the command object used to represent IRC commands. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | typedef | COMMAND | COMMAND | 32 | 43 | Defines the data structure and interface for the COMMAND entity used in the server's request handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | name | _COMMAND::name | 34 | 34 | Defines the structure and type of the _COMMAND entity used for parsing command line arguments. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | function | _COMMAND::function | 35 | 35 | Defines the structure and type of the command object being parsed. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | PARAMS | _COMMAND::PARAMS | 35 | 35 | Defines the structure and type of the command parameters passed to the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | type | _COMMAND::type | 37 | 37 | Defines the data structure and type for the _COMMAND entity, including its field types and shape. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | min_argc | _COMMAND::min_argc | 38 | 38 | Defines the structure and type of the minimum argument count for the _COMMAND command. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | max_argc | _COMMAND::max_argc | 39 | 39 | Defines the data structure and type for the maximum argument count field within the command handler. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | penalty | _COMMAND::penalty | 40 | 40 | Defines the data structure and type for the penalty field within the command object. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | lcount | _COMMAND::lcount | 41 | 41 | Defines the data structure and type for the command field within the IRC server's command parsing logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | bytes | _COMMAND::bytes | 42 | 42 | Defines the structure and type of the parsed command field data. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | struct | _Proc_Stat | _Proc_Stat | 21 | 24 | Defines the data structure for process statistics, including PID and pipe file descriptor. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | typedef | PROC_STAT | PROC_STAT | 21 | 24 | Defines the data structure for process statistics, including PID and pipe file descriptor. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | field | pid | _Proc_Stat::pid | 22 | 22 | Defines the data structure and type for the process statistics record. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | field | pipe_fd | _Proc_Stat::pipe_fd | 23 | 23 | Declares a data structure representing a process state, specifically defining the pipe file descriptor as a scalar field within the _Proc_Stat struct. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | sockaddr | sockaddr | 181 | 181 | Defines the sockaddr structure, a data type used to represent network address information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | sockaddr_in | sockaddr_in | 191 | 191 | Defines the structure and layout of network address data structures used for server configuration and connection handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | sockaddr_in | sockaddr_in | 191 | 191 | Defines the structure and layout of network address data structures used for server configuration and connection handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | hostent | hostent | 192 | 192 | Defines the structure of the hostent data type used for resolving hostnames. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | addrinfo | addrinfo | 239 | 239 | Defines the structure and layout of the addrinfo data type used for network address resolution. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | addrinfo | addrinfo | 240 | 240 | Defines the structure and layout of the addrinfo data type used for network address resolution. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | hostent | hostent | 274 | 274 | Defines the structure of the hostent data type used for resolving hostnames. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | in_addr | in_addr | 288 | 288 | Defines the data structure for network address information used in the server's networking logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr_un | sockaddr_un | 383 | 383 | Defines the structure of the sockaddr_un struct, representing network address information used for Unix domain sockets. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr_un | sockaddr_un | 414 | 414 | Defines the structure of the sockaddr_un struct, representing network address information used for Unix domain sockets. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr_un | sockaddr_un | 431 | 431 | Defines the structure of the sockaddr_un struct, representing network address information used for Unix domain sockets. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT8 | UINT8 | 73 | 73 | Defines the data type and structure for the UINT8 type used in the ngIRCd source code. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT16 | UINT16 | 74 | 74 | Defines the data type and structure for the integer constant UINT16 used in the ngIRCd source code. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT32 | UINT32 | 75 | 75 | Defines the data type and structure for the UINT32 type used in the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT8 | UINT8 | 77 | 77 | Defines the data type and structure for the unsigned char type used in the ngIRCd source code. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT16 | UINT16 | 78 | 78 | Defines the data type UINT16 used for representing numeric values within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT32 | UINT32 | 79 | 79 | Defines the data type and structure for the UINT32 type used in the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | <anonymous> | <anonymous> | 85 | 85 | Defines a typedef for the boolean type, representing a core data structure used within the application. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | struct | timeval | timeval | 139 | 139 | Defines the structure and layout of the timeval data type used for timing information. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | struct | _code | _code | 167 | 170 | Defines the data structure for code objects with name and value fields. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | typedef | CODE | CODE | 167 | 170 | Defines a data structure for a code object with a name and value. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | field | c_name | _code::c_name | 168 | 168 | Declares a scalar variable named c_name of type char used within the SpecBuilder tool. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | field | c_val | _code::c_val | 169 | 169 | Declares a scalar integer field named c_val within the code structure. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | addrinfo | addrinfo | 29 | 29 |  |  |  | struct addrinfo
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | addrinfo | addrinfo | 30 | 30 |  |  |  | struct addrinfo
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | sockaddr | sockaddr | 151 | 151 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | struct | sockaddr | sockaddr | 151 | 151 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | union | <anonymous> | <anonymous> | 35 | 39 |  |  |  | union { struct sockaddr sa; struct sockaddr_in sin4; struct sockaddr_in6 sin6; }
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | typedef | ng_ipaddr_t | ng_ipaddr_t | 35 | 39 |  |  |  | typedef union { struct sockaddr sa; struct sockaddr_in sin4; struct sockaddr_in6 sin6; } ng_ipaddr_t;
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sa | sa | 36 | 36 |  | struct sockaddr | structured_object | struct sockaddr sa;
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr | sockaddr | 36 | 36 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sin4 | sin4 | 37 | 37 |  | struct sockaddr_in | structured_object | struct sockaddr_in sin4;
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr_in | sockaddr_in | 37 | 37 |  |  |  | struct sockaddr_in
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sin6 | sin6 | 38 | 38 |  | struct sockaddr_in6 | structured_object | struct sockaddr_in6 sin6;
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr_in6 | sockaddr_in6 | 38 | 38 |  |  |  | struct sockaddr_in6
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | NG_IP_ADDR_DONTUSE | NG_IP_ADDR_DONTUSE | 42 | 44 |  |  |  | struct NG_IP_ADDR_DONTUSE { struct sockaddr_in sin4; }
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | field | sin4 | NG_IP_ADDR_DONTUSE::sin4 | 43 | 43 | NG_IP_ADDR_DONTUSE | struct sockaddr_in | structured_object | struct sockaddr_in sin4;
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | sockaddr_in | NG_IP_ADDR_DONTUSE::sockaddr_in | 43 | 43 | NG_IP_ADDR_DONTUSE |  |  | struct sockaddr_in
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | struct | NG_IP_ADDR_DONTUSE | NG_IP_ADDR_DONTUSE | 45 | 45 |  |  |  | struct NG_IP_ADDR_DONTUSE
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | typedef | ng_ipaddr_t | ng_ipaddr_t | 45 | 45 |  |  |  | typedef struct NG_IP_ADDR_DONTUSE ng_ipaddr_t;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_length | array_length | 91 | 102 |  |  |  | size_t array_length(const array * const a, size_t membersize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_start | array_start | 271 | 276 |  |  |  | void * array_start(const array * const a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | struct | <anonymous> | <anonymous> | 22 | 26 |  |  |  | struct { char * mem; size_t allocated; size_t used; }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | typedef | array | array | 22 | 26 |  |  |  | typedef struct { char * mem; size_t allocated; size_t used; } array;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | field | mem | mem | 23 | 23 |  | char | scalar_or_unknown | char * mem;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | field | allocated | allocated | 24 | 24 |  | size_t | scalar_or_unknown | size_t allocated;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.h | field | used | used | 25 | 25 |  | size_t | scalar_or_unknown | size_t used;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetListBans | Channel_GetListBans | 67 | 72 |  |  |  | list_head * Channel_GetListBans(CHANNEL *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetListExcepts | Channel_GetListExcepts | 75 | 80 |  |  |  | list_head * Channel_GetListExcepts(CHANNEL *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetListInvites | Channel_GetListInvites | 83 | 88 |  |  |  | list_head * Channel_GetListInvites(CHANNEL *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | Conf_Channel | Conf_Channel | 99 | 99 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Free_Channel | Free_Channel | 205 | 215 |  |  |  | static void Free_Channel(CHANNEL *chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Part | Channel_Part | 293 | 325 |  |  |  | GLOBAL bool Channel_Part(CLIENT * Client, CLIENT * Origin, const char *Name, const char *Reason)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CountVisible | Channel_CountVisible | 453 | 470 |  |  |  | GLOBAL unsigned long Channel_CountVisible (CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_MemberCount | Channel_MemberCount | 473 | 488 |  |  |  | GLOBAL unsigned long Channel_MemberCount( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CountForUser | Channel_CountForUser | 491 | 509 |  |  |  | GLOBAL int Channel_CountForUser( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Name | Channel_Name | 512 | 517 |  |  |  | GLOBAL const char * Channel_Name( const CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Modes | Channel_Modes | 520 | 525 |  |  |  | GLOBAL char * Channel_Modes( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_HasMode | Channel_HasMode | 528 | 533 |  |  |  | GLOBAL bool Channel_HasMode( CHANNEL *Chan, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Key | Channel_Key | 536 | 541 |  |  |  | GLOBAL char * Channel_Key( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_MaxUsers | Channel_MaxUsers | 544 | 549 |  |  |  | GLOBAL unsigned long Channel_MaxUsers( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_First | Channel_First | 552 | 556 |  |  |  | GLOBAL CHANNEL * Channel_First( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Next | Channel_Next | 559 | 564 |  |  |  | GLOBAL CHANNEL * Channel_Next( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Search | Channel_Search | 567 | 589 |  |  |  | GLOBAL CHANNEL * Channel_Search( const char *Name )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_FirstMember | Channel_FirstMember | 592 | 597 |  |  |  | GLOBAL CL2CHAN * Channel_FirstMember( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_NextMember | Channel_NextMember | 600 | 606 |  |  |  | GLOBAL CL2CHAN * Channel_NextMember( CHANNEL *Chan, CL2CHAN *Cl2Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_FirstChannelOf | Channel_FirstChannelOf | 609 | 614 |  |  |  | GLOBAL CL2CHAN * Channel_FirstChannelOf( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetChannel | Channel_GetChannel | 634 | 639 |  |  |  | GLOBAL CHANNEL * Channel_GetChannel( CL2CHAN *Cl2Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_IsValidName | Channel_IsValidName | 642 | 657 |  |  |  | GLOBAL bool Channel_IsValidName( const char *Name )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ModeAdd | Channel_ModeAdd | 660 | 680 |  |  |  | GLOBAL bool Channel_ModeAdd( CHANNEL *Chan, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ModeDel | Channel_ModeDel | 683 | 704 |  |  |  | GLOBAL bool Channel_ModeDel( CHANNEL *Chan, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserModeDel | Channel_UserModeDel | 735 | 762 |  |  |  | GLOBAL bool Channel_UserModeDel( CHANNEL *Chan, CLIENT *Client, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserModes | Channel_UserModes | 765 | 779 |  |  |  | GLOBAL char * Channel_UserModes( CHANNEL *Chan, CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserHasMode | Channel_UserHasMode | 790 | 804 |  |  |  | GLOBAL bool Channel_UserHasMode( CHANNEL *Chan, CLIENT *Client, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_IsMemberOf | Channel_IsMemberOf | 807 | 815 |  |  |  | GLOBAL bool Channel_IsMemberOf( CHANNEL *Chan, CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Topic | Channel_Topic | 818 | 825 |  |  |  | GLOBAL char * Channel_Topic( CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_TopicTime | Channel_TopicTime | 830 | 835 |  |  |  | GLOBAL unsigned int Channel_TopicTime(CHANNEL *Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_TopicWho | Channel_TopicWho | 838 | 843 |  |  |  | GLOBAL char * Channel_TopicWho(CHANNEL *Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CreationTime | Channel_CreationTime | 846 | 851 |  |  |  | GLOBAL unsigned int Channel_CreationTime(CHANNEL *Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetTopic | Channel_SetTopic | 856 | 881 |  |  |  | GLOBAL void Channel_SetTopic(CHANNEL *Chan, CLIENT *Client, const char *Topic)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetModes | Channel_SetModes | 884 | 891 |  |  |  | GLOBAL void Channel_SetModes( CHANNEL *Chan, const char *Modes )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetKey | Channel_SetKey | 894 | 902 |  |  |  | GLOBAL void Channel_SetKey( CHANNEL *Chan, const char *Key )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_SetMaxUsers | Channel_SetMaxUsers | 905 | 912 |  |  |  | GLOBAL void Channel_SetMaxUsers(CHANNEL *Chan, unsigned long Count)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Create | Channel_Create | 997 | 1021 |  |  |  | GLOBAL CHANNEL * Channel_Create( const char *Name )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Get_Cl2Chan | Get_Cl2Chan | 1024 | 1039 |  |  |  | static CL2CHAN * Get_Cl2Chan( CHANNEL *Chan, CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Add_Client | Add_Client | 1042 | 1068 |  |  |  | static CL2CHAN * Add_Client( CHANNEL *Chan, CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_AddBan | Channel_AddBan | 1161 | 1167 |  |  |  | GLOBAL bool Channel_AddBan(CHANNEL *c, const char *mask, const char *who )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1164 | 1164 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1173 | 1173 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_AddInvite | Channel_AddInvite | 1179 | 1185 |  |  |  | GLOBAL bool Channel_AddInvite(CHANNEL *c, const char *mask, bool onlyonce, const char *who )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1182 | 1182 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1189 | 1189 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_elem | list_elem | 1192 | 1192 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ShowBans | Channel_ShowBans | 1213 | 1223 |  |  |  | GLOBAL bool Channel_ShowBans( CLIENT *Client, CHANNEL *Channel )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1216 | 1216 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ShowExcepts | Channel_ShowExcepts | 1226 | 1236 |  |  |  | GLOBAL bool Channel_ShowExcepts( CLIENT *Client, CHANNEL *Channel )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1229 | 1229 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_ShowInvites | Channel_ShowInvites | 1239 | 1249 |  |  |  | GLOBAL bool Channel_ShowInvites( CLIENT *Client, CHANNEL *Channel )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | struct | list_head | list_head | 1242 | 1242 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_CheckKey | Channel_CheckKey | 1272 | 1319 |  |  |  | GLOBAL bool Channel_CheckKey(CHANNEL *Chan, CLIENT *Client, const char *Key)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Get_First_Cl2Chan | Get_First_Cl2Chan | 1322 | 1326 |  |  |  | static CL2CHAN * Get_First_Cl2Chan( CLIENT *Client, CHANNEL *Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Get_Next_Cl2Chan | Get_Next_Cl2Chan | 1329 | 1344 |  |  |  | static CL2CHAN * Get_Next_Cl2Chan( CL2CHAN *Start, CLIENT *Client, CHANNEL *Channel )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Delete_Channel | Delete_Channel | 1350 | 1376 |  |  |  | static void Delete_Channel(CHANNEL *Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CHANNEL | _CHANNEL | 26 | 44 |  |  |  | struct _CHANNEL { struct _CHANNEL *next; char name[CHANNEL_NAME_LEN]; /* Name of the channel */ UINT32 hash; /* Hash of the (lowecase!) name */ char modes[CHANNEL_MODE_LEN]; /* Channel modes */ array topic; /* Topic of the channel */ #ifndef STRICT_RFC time_t creation_time; /* Channel creation time
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CHANNEL | CHANNEL | 26 | 44 |  |  |  | typedef struct _CHANNEL { struct _CHANNEL *next; char name[CHANNEL_NAME_LEN]; /* Name of the channel */ UINT32 hash; /* Hash of the (lowecase!) name */ char modes[CHANNEL_MODE_LEN]; /* Channel modes */ array topic; /* Topic of the channel */ #ifndef STRICT_RFC time_t creation_time; /* Channel creati
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | _CHANNEL | _CHANNEL::_CHANNEL | 28 | 28 | _CHANNEL | struct _CHANNEL | structured_object | struct _CHANNEL *next;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CHANNEL | _CHANNEL::_CHANNEL | 28 | 28 | _CHANNEL |  |  | struct _CHANNEL
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | name | _CHANNEL::name | 29 | 29 | _CHANNEL | char | scalar_or_unknown | char name[CHANNEL_NAME_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | hash | _CHANNEL::hash | 30 | 30 | _CHANNEL | UINT32 | scalar_or_unknown | UINT32 hash;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | modes | _CHANNEL::modes | 31 | 31 | _CHANNEL | char | scalar_or_unknown | char modes[CHANNEL_MODE_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | topic | _CHANNEL::topic | 32 | 32 | _CHANNEL | array | array_or_collection | array topic;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | creation_time | _CHANNEL::creation_time | 34 | 34 | _CHANNEL | time_t | scalar_or_unknown | time_t creation_time;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | topic_time | _CHANNEL::topic_time | 35 | 35 | _CHANNEL | time_t | scalar_or_unknown | time_t topic_time;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | topic_who | _CHANNEL::topic_who | 36 | 36 | _CHANNEL | char | scalar_or_unknown | char topic_who[CLIENT_NICK_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | key | _CHANNEL::key | 38 | 38 | _CHANNEL | char | scalar_or_unknown | char key[CLIENT_PASS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | maxusers | _CHANNEL::maxusers | 39 | 39 | _CHANNEL | unsigned long | scalar_or_unknown | unsigned long maxusers;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | list_bans | _CHANNEL::list_bans | 40 | 40 | _CHANNEL | struct list_head | structured_object | struct list_head list_bans;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | list_head | _CHANNEL::list_head | 40 | 40 | _CHANNEL |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | list_excepts | _CHANNEL::list_excepts | 41 | 41 | _CHANNEL | struct list_head | structured_object | struct list_head list_excepts;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | list_head | _CHANNEL::list_head | 41 | 41 | _CHANNEL |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | list_head | _CHANNEL::list_head | 42 | 42 | _CHANNEL |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | list_invites | _CHANNEL::list_invites | 42 | 42 | _CHANNEL | struct list_head | structured_object | struct list_head list_invites;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | keyfile | _CHANNEL::keyfile | 43 | 43 | _CHANNEL | array | array_or_collection | array keyfile;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CLIENT2CHAN | _CLIENT2CHAN | 46 | 52 |  |  |  | struct _CLIENT2CHAN { struct _CLIENT2CHAN *next; CLIENT *client; CHANNEL *channel; char modes[CHANNEL_MODE_LEN]; /* User-Modes in Channel */ }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CL2CHAN | CL2CHAN | 46 | 52 |  |  |  | typedef struct _CLIENT2CHAN { struct _CLIENT2CHAN *next; CLIENT *client; CHANNEL *channel; char modes[CHANNEL_MODE_LEN]; /* User-Modes in Channel */ } CL2CHAN;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | _CLIENT2CHAN | _CLIENT2CHAN::_CLIENT2CHAN | 48 | 48 | _CLIENT2CHAN | struct _CLIENT2CHAN | structured_object | struct _CLIENT2CHAN *next;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | struct | _CLIENT2CHAN | _CLIENT2CHAN::_CLIENT2CHAN | 48 | 48 | _CLIENT2CHAN |  |  | struct _CLIENT2CHAN
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | CLIENT | _CLIENT2CHAN::CLIENT | 49 | 49 | _CLIENT2CHAN | CLIENT | scalar_or_unknown | CLIENT *client;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | CHANNEL | _CLIENT2CHAN::CHANNEL | 50 | 50 | _CLIENT2CHAN | CHANNEL | scalar_or_unknown | CHANNEL *channel;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | field | modes | _CLIENT2CHAN::modes | 51 | 51 | _CLIENT2CHAN | char | scalar_or_unknown | char modes[CHANNEL_MODE_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CHANNEL | CHANNEL | 56 | 56 |  |  |  | typedef POINTER CHANNEL;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.h | typedef | CL2CHAN | CL2CHAN | 57 | 57 |  |  |  | typedef POINTER CL2CHAN;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | struct | list_head | list_head | 28 | 28 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_AddMask | Class_AddMask | 96 | 109 |  |  |  | GLOBAL bool Class_AddMask(const int Class, const char *Pattern, time_t ValidUntil, const char *Reason)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_DeleteMask | Class_DeleteMask | 111 | 121 |  |  |  | GLOBAL void Class_DeleteMask(const int Class, const char *Pattern)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_GetList | Class_GetList | 123 | 129 |  |  |  | list_head * Class_GetList(const int Class)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_Expire | Class_Expire | 131 | 136 |  |  |  | GLOBAL void Class_Expire(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_Cap | Client_Cap | 28 | 34 |  |  |  | GLOBAL int Client_Cap(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_CapSet | Client_CapSet | 36 | 45 |  |  |  | GLOBAL void Client_CapSet(CLIENT *Client, int Cap)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | struct | hostent | hostent | 74 | 74 |  |  |  | struct hostent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Init_New_Client | Init_New_Client | 179 | 224 |  |  |  | static CLIENT * Init_New_Client(CONN_ID Idx, CLIENT *Introducer, CLIENT *TopServer, int Type, const char *ID, const char *User, const char *Hostname, const char *Info, int Hops, int Token, const char *Modes, bool Idented)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetOrigUser | Client_SetOrigUser | 428 | 437 |  |  |  | GLOBAL void Client_SetOrigUser(CLIENT UNUSED *Client, const char UNUSED *User)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetAccountName | Client_SetAccountName | 475 | 488 |  |  |  | GLOBAL void Client_SetAccountName(CLIENT *Client, const char *AccountName)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Type | Client_Type | 680 | 685 |  |  |  | GLOBAL int Client_Type( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ID | Client_ID | 696 | 706 |  |  |  | GLOBAL char * Client_ID( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Info | Client_Info | 709 | 714 |  |  |  | GLOBAL char * Client_Info( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_OrigUser | Client_OrigUser | 734 | 737 |  |  |  | GLOBAL char * Client_OrigUser(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_UpdateCloakedHostname | Client_UpdateCloakedHostname | 815 | 852 |  |  |  | GLOBAL void Client_UpdateCloakedHostname(CLIENT *Client, CLIENT *Origin, const char *Hostname)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Modes | Client_Modes | 854 | 859 |  |  |  | GLOBAL char * Client_Modes( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Flags | Client_Flags | 862 | 867 |  |  |  | GLOBAL char * Client_Flags( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HasMode | Client_HasMode | 979 | 984 |  |  |  | GLOBAL bool Client_HasMode( CLIENT *Client, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HasFlag | Client_HasFlag | 987 | 992 |  |  |  | GLOBAL bool Client_HasFlag( CLIENT *Client, char Flag )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_AccountName | Client_AccountName | 1003 | 1008 |  |  |  | GLOBAL char * Client_AccountName(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_CheckNick | Client_CheckNick | 1021 | 1056 |  |  |  | GLOBAL bool Client_CheckNick(CLIENT *Client, char *Nick)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_UserCount | Client_UserCount | 1110 | 1114 |  |  |  | GLOBAL long Client_UserCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ServiceCount | Client_ServiceCount | 1117 | 1121 |  |  |  | GLOBAL long Client_ServiceCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyUserCount | Client_MyUserCount | 1131 | 1135 |  |  |  | GLOBAL long Client_MyUserCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyServiceCount | Client_MyServiceCount | 1138 | 1142 |  |  |  | GLOBAL long Client_MyServiceCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MaxUserCount | Client_MaxUserCount | 1195 | 1199 |  |  |  | GLOBAL long Client_MaxUserCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyMaxUserCount | Client_MyMaxUserCount | 1202 | 1206 |  |  |  | GLOBAL long Client_MyMaxUserCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_IsValidNick | Client_IsValidNick | 1215 | 1238 |  |  |  | GLOBAL bool Client_IsValidNick(const char *Nick)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_GetLastWhowasIndex | Client_GetLastWhowasIndex | 1253 | 1257 |  |  |  | GLOBAL int Client_GetLastWhowasIndex( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Introduce | Client_Introduce | 1313 | 1345 |  |  |  | GLOBAL void Client_Introduce(CLIENT *From, CLIENT *Client, int Type)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Count | Count | 1348 | 1361 |  |  |  | static unsigned long Count( CLIENT_TYPE Type )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | MyCount | MyCount | 1364 | 1377 |  |  |  | static unsigned long MyCount( CLIENT_TYPE Type )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | New_Client_Struct | New_Client_Struct | 1385 | 1406 |  |  |  | static CLIENT * New_Client_Struct( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_TypeText | Client_TypeText | 1518 | 1535 |  |  |  | GLOBAL const char * Client_TypeText(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _CLIENT | _CLIENT | 41 | 66 |  |  |  | struct _CLIENT { time_t starttime; /* Start time of link */ char id[CLIENT_ID_LEN]; /* nick (user) / ID (server) */ UINT32 hash; /* hash of lower-case ID */ POINTER *next; /* pointer to next client structure */ CLIENT_TYPE type; /* type of client, see CLIENT_xxx */ CONN_ID conn_id; /* ID of the conn
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | typedef | CLIENT | CLIENT | 41 | 66 |  |  |  | typedef struct _CLIENT { time_t starttime; /* Start time of link */ char id[CLIENT_ID_LEN]; /* nick (user) / ID (server) */ UINT32 hash; /* hash of lower-case ID */ POINTER *next; /* pointer to next client structure */ CLIENT_TYPE type; /* type of client, see CLIENT_xxx */ CONN_ID conn_id; /* ID of
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | starttime | _CLIENT::starttime | 43 | 43 | _CLIENT | time_t | scalar_or_unknown | time_t starttime;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | id | _CLIENT::id | 44 | 44 | _CLIENT | char | scalar_or_unknown | char id[CLIENT_ID_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | hash | _CLIENT::hash | 45 | 45 | _CLIENT | UINT32 | scalar_or_unknown | UINT32 hash;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | POINTER | _CLIENT::POINTER | 46 | 46 | _CLIENT | POINTER | pointer_or_reference | POINTER *next;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | type | _CLIENT::type | 47 | 47 | _CLIENT | CLIENT_TYPE | scalar_or_unknown | CLIENT_TYPE type;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | conn_id | _CLIENT::conn_id | 48 | 48 | _CLIENT | CONN_ID | scalar_or_unknown | CONN_ID conn_id;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | _CLIENT | _CLIENT::_CLIENT | 49 | 49 | _CLIENT | struct _CLIENT | structured_object | struct _CLIENT *introducer;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _CLIENT | _CLIENT::_CLIENT | 49 | 49 | _CLIENT |  |  | struct _CLIENT
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | _CLIENT | _CLIENT::_CLIENT | 50 | 50 | _CLIENT | struct _CLIENT | structured_object | struct _CLIENT *topserver;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _CLIENT | _CLIENT::_CLIENT | 50 | 50 | _CLIENT |  |  | struct _CLIENT
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | host | _CLIENT::host | 51 | 51 | _CLIENT | char | scalar_or_unknown | char host[CLIENT_HOST_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | cloaked | _CLIENT::cloaked | 52 | 52 | _CLIENT | char | scalar_or_unknown | char *cloaked;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | ipa_text | _CLIENT::ipa_text | 53 | 53 | _CLIENT | char | scalar_or_unknown | char *ipa_text;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | user | _CLIENT::user | 54 | 54 | _CLIENT | char | scalar_or_unknown | char user[CLIENT_USER_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | orig_user | _CLIENT::orig_user | 56 | 56 | _CLIENT | char | scalar_or_unknown | char orig_user[CLIENT_AUTHUSER_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | info | _CLIENT::info | 59 | 59 | _CLIENT | char | scalar_or_unknown | char info[CLIENT_INFO_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | modes | _CLIENT::modes | 60 | 60 | _CLIENT | char | scalar_or_unknown | char modes[CLIENT_MODE_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | hops | _CLIENT::hops | 61 | 61 | _CLIENT | int | scalar_or_unknown | int hops, token, mytoken;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | away | _CLIENT::away | 62 | 62 | _CLIENT | char | scalar_or_unknown | char *away;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | flags | _CLIENT::flags | 63 | 63 | _CLIENT | char | scalar_or_unknown | char flags[CLIENT_FLAGS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | account_name | _CLIENT::account_name | 64 | 64 | _CLIENT | char | scalar_or_unknown | char *account_name;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | capabilities | _CLIENT::capabilities | 65 | 65 | _CLIENT | int | scalar_or_unknown | int capabilities;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | typedef | CLIENT | CLIENT | 70 | 70 |  |  |  | typedef POINTER CLIENT;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | struct | _WHOWAS | _WHOWAS | 75 | 83 |  |  |  | struct _WHOWAS { time_t time; /* time stamp of entry or 0 if unused */ char id[CLIENT_NICK_LEN]; /* client nickname */ char host[CLIENT_HOST_LEN]; /* hostname of the client */ char user[CLIENT_USER_LEN]; /* user name ("login") */ char info[CLIENT_INFO_LEN]; /* long user name */ char server[CLIENT_HO
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | typedef | WHOWAS | WHOWAS | 75 | 83 |  |  |  | typedef struct _WHOWAS { time_t time; /* time stamp of entry or 0 if unused */ char id[CLIENT_NICK_LEN]; /* client nickname */ char host[CLIENT_HOST_LEN]; /* hostname of the client */ char user[CLIENT_USER_LEN]; /* user name ("login") */ char info[CLIENT_INFO_LEN]; /* long user name */ char server[C
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | time | _WHOWAS::time | 77 | 77 | _WHOWAS | time_t | scalar_or_unknown | time_t time;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | id | _WHOWAS::id | 78 | 78 | _WHOWAS | char | scalar_or_unknown | char id[CLIENT_NICK_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | host | _WHOWAS::host | 79 | 79 | _WHOWAS | char | scalar_or_unknown | char host[CLIENT_HOST_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | user | _WHOWAS::user | 80 | 80 | _WHOWAS | char | scalar_or_unknown | char user[CLIENT_USER_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | info | _WHOWAS::info | 81 | 81 | _WHOWAS | char | scalar_or_unknown | char info[CLIENT_INFO_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.h | field | server | _WHOWAS::server | 82 | 82 | _WHOWAS | char | scalar_or_unknown | char server[CLIENT_HOST_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | struct | ConnSSL_State | ConnSSL_State | 35 | 46 |  |  |  | struct ConnSSL_State { #ifdef HAVE_LIBSSL SSL *ssl; #endif #ifdef HAVE_LIBGNUTLS gnutls_session_t gnutls_session; void *cookie; /* pointer to server configuration structure (for outgoing connections), or NULL. */ size_t x509_cred_idx; /* index of active x509 credential record */ #endif char *fingerp
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | SSL | ConnSSL_State::SSL | 37 | 37 | ConnSSL_State | SSL | scalar_or_unknown | SSL *ssl;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | gnutls_session | ConnSSL_State::gnutls_session | 40 | 40 | ConnSSL_State | gnutls_session_t | scalar_or_unknown | gnutls_session_t gnutls_session;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | cookie | ConnSSL_State::cookie | 41 | 41 | ConnSSL_State | void | scalar_or_unknown | void *cookie;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | x509_cred_idx | ConnSSL_State::x509_cred_idx | 43 | 43 | ConnSSL_State | size_t | scalar_or_unknown | size_t x509_cred_idx;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf-ssl.h | field | fingerprint | ConnSSL_State::fingerprint | 45 | 45 | ConnSSL_State | char | scalar_or_unknown | char *fingerprint;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | passwd | passwd | 340 | 340 |  |  |  | struct passwd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | group | group | 341 | 341 |  |  |  | struct group
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 345 | 345 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | dirent | dirent | 922 | 922 |  |  |  | struct dirent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 1171 | 1172 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 1175 | 1175 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | passwd | passwd | 1346 | 1346 |  |  |  | struct passwd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | group | group | 1347 | 1347 |  |  |  | struct group
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 2025 | 2025 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 2053 | 2053 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | hostent | hostent | 2140 | 2140 |  |  |  | struct hostent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | rlimit | rlimit | 2144 | 2144 |  |  |  | struct rlimit
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Channel | Conf_Channel | 2289 | 2289 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | Conf_Oper | Conf_Oper | 36 | 40 |  |  |  | struct Conf_Oper { char name[CLIENT_PASS_LEN]; /**< Name (ID) */ char pwd[CLIENT_PASS_LEN]; /**< Password */ char *mask; /**< Allowed host mask */ }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | typedef | CONF_SERVER | CONF_SERVER | 47 | 68 |  |  |  | typedef struct _Conf_Server { char host[HOST_LEN]; /**< Hostname */ char name[CLIENT_ID_LEN]; /**< IRC client ID */ char pwd_in[CLIENT_PASS_LEN]; /**< Password which must be received */ char pwd_out[CLIENT_PASS_LEN]; /**< Password to send to the peer */ UINT16 port; /**< Server port to connect to */
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | name | _Conf_Server::name | 50 | 50 | _Conf_Server | char | scalar_or_unknown | char name[CLIENT_ID_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | pwd_out | _Conf_Server::pwd_out | 52 | 52 | _Conf_Server | char | scalar_or_unknown | char pwd_out[CLIENT_PASS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | lasttry | _Conf_Server::lasttry | 55 | 55 | _Conf_Server | time_t | scalar_or_unknown | time_t lasttry;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | res_stat | _Conf_Server::res_stat | 56 | 56 | _Conf_Server | PROC_STAT | scalar_or_unknown | PROC_STAT res_stat;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | conn_id | _Conf_Server::conn_id | 58 | 58 | _Conf_Server | CONN_ID | scalar_or_unknown | CONN_ID conn_id;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | ng_ipaddr_t | _Conf_Server::ng_ipaddr_t | 61 | 61 | _Conf_Server | ng_ipaddr_t | scalar_or_unknown | ng_ipaddr_t dst_addr[2];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | svs_mask | _Conf_Server::svs_mask | 66 | 66 | _Conf_Server | char | scalar_or_unknown | char svs_mask[CLIENT_ID_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | Conf_Channel | Conf_Channel | 87 | 96 |  |  |  | struct Conf_Channel { char name[CHANNEL_NAME_LEN]; /**< Name of the channel */ char *modes[512]; /**< Initial channel modes to evaluate */ char key[CLIENT_PASS_LEN]; /**< Channel key ("password", mode "k" ) */ char topic[COMMAND_LEN]; /**< Initial topic */ char keyfile[512]; /**< Path and name of ch
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | name | Conf_Channel::name | 88 | 88 | Conf_Channel | char | scalar_or_unknown | char name[CHANNEL_NAME_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | modes | Conf_Channel::modes | 89 | 89 | Conf_Channel | char | scalar_or_unknown | char *modes[512];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | topic | Conf_Channel::topic | 91 | 91 | Conf_Channel | char | scalar_or_unknown | char topic[COMMAND_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | maxusers | Conf_Channel::maxusers | 94 | 94 | Conf_Channel | unsigned long | scalar_or_unknown | unsigned long maxusers;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | struct | <anonymous> | <anonymous> | 69 | 73 |  |  |  | struct { int refcnt; gnutls_certificate_credentials_t x509_cred; gnutls_dh_params_t dh_params; }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | typedef | x509_cred_slot | x509_cred_slot | 69 | 73 |  |  |  | typedef struct { int refcnt; gnutls_certificate_credentials_t x509_cred; gnutls_dh_params_t dh_params; } x509_cred_slot;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | field | x509_cred | x509_cred | 71 | 71 |  | gnutls_certificate_credentials_t | scalar_or_unknown | gnutls_certificate_credentials_t x509_cred;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | field | dh_params | dh_params | 72 | 72 |  | gnutls_dh_params_t | scalar_or_unknown | gnutls_dh_params_t dh_params;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | struct | stat | stat | 94 | 94 |  |  |  | struct stat
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | timeval | timeval | 671 | 671 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | request_info | request_info | 1369 | 1369 |  |  |  | struct request_info
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | typedef | CONN_ID | CONN_ID | 46 | 46 |  |  |  | typedef int CONN_ID;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | typedef | ZIPDATA | ZIPDATA | 64 | 71 |  |  |  | typedef struct _ZipData { z_stream in; /* "Handle" for input stream */ z_stream out; /* "Handle" for output stream */ array rbuf; /* Read buffer (compressed) */ array wbuf; /* Write buffer (uncompressed) */ long bytes_in, bytes_out; /* Counter for statistics (uncompressed!) */ } ZIPDATA;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | rbuf | _ZipData::rbuf | 68 | 68 | _ZipData | array | array_or_collection | array rbuf;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | struct | _Connection | _Connection | 74 | 107 |  |  |  | struct _Connection { int sock; /* Socket handle */ ng_ipaddr_t addr; /* Client address */ PROC_STAT proc_stat; /* Status of resolver process */ char host[HOST_LEN]; /* Hostname */ char *pwd; /* password received of the client */ array rbuf; /* Read buffer */ array wbuf; /* Write buffer */ time_t sig
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | typedef | CONNECTION | CONNECTION | 74 | 107 |  |  |  | typedef struct _Connection { int sock; /* Socket handle */ ng_ipaddr_t addr; /* Client address */ PROC_STAT proc_stat; /* Status of resolver process */ char host[HOST_LEN]; /* Hostname */ char *pwd; /* password received of the client */ array rbuf; /* Read buffer */ array wbuf; /* Write buffer */ ti
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | sock | _Connection::sock | 76 | 76 | _Connection | int | scalar_or_unknown | int sock;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | addr | _Connection::addr | 77 | 77 | _Connection | ng_ipaddr_t | scalar_or_unknown | ng_ipaddr_t addr;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | proc_stat | _Connection::proc_stat | 78 | 78 | _Connection | PROC_STAT | scalar_or_unknown | PROC_STAT proc_stat;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | host | _Connection::host | 79 | 79 | _Connection | char | scalar_or_unknown | char host[HOST_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | pwd | _Connection::pwd | 80 | 80 | _Connection | char | scalar_or_unknown | char *pwd;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | rbuf | _Connection::rbuf | 81 | 81 | _Connection | array | array_or_collection | array rbuf;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | wbuf | _Connection::wbuf | 82 | 82 | _Connection | array | array_or_collection | array wbuf;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | signon | _Connection::signon | 83 | 83 | _Connection | time_t | scalar_or_unknown | time_t signon;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | lastdata | _Connection::lastdata | 84 | 84 | _Connection | time_t | scalar_or_unknown | time_t lastdata;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | lastping | _Connection::lastping | 85 | 85 | _Connection | time_t | scalar_or_unknown | time_t lastping;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | lastprivmsg | _Connection::lastprivmsg | 86 | 86 | _Connection | time_t | scalar_or_unknown | time_t lastprivmsg;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | delaytime | _Connection::delaytime | 87 | 87 | _Connection | time_t | scalar_or_unknown | time_t delaytime;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | bytes_in | _Connection::bytes_in | 88 | 88 | _Connection | long | scalar_or_unknown | long bytes_in, bytes_out;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | msg_in | _Connection::msg_in | 89 | 89 | _Connection | long | scalar_or_unknown | long msg_in, msg_out;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | flag | _Connection::flag | 90 | 90 | _Connection | int | scalar_or_unknown | int flag;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | options | _Connection::options | 91 | 91 | _Connection | UINT16 | scalar_or_unknown | UINT16 options;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | bps | _Connection::bps | 92 | 92 | _Connection | UINT16 | scalar_or_unknown | UINT16 bps;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | CLIENT | _Connection::CLIENT | 93 | 93 | _Connection | CLIENT | scalar_or_unknown | CLIENT *client;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | struct | ConnSSL_State | _Connection::ConnSSL_State | 98 | 98 | _Connection |  |  | struct ConnSSL_State
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | ssl_state | _Connection::ssl_state | 98 | 98 | _Connection | struct ConnSSL_State | structured_object | struct ConnSSL_State ssl_state;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | auth_ping | _Connection::auth_ping | 101 | 101 | _Connection | long | scalar_or_unknown | long auth_ping;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | iconv_from | _Connection::iconv_from | 104 | 104 | _Connection | iconv_t | scalar_or_unknown | iconv_t iconv_from;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | iconv_to | _Connection::iconv_to | 105 | 105 | _Connection | iconv_t | scalar_or_unknown | iconv_t iconv_to;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | <anonymous> | <anonymous> | 34 | 41 |  |  |  | struct { #ifdef PROTOTYPES void (*callback)(int, short); #else void (*callback)(); #endif short what; }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | typedef | io_event | io_event | 34 | 41 |  |  |  | typedef struct { #ifdef PROTOTYPES void (*callback)(int, short); #else void (*callback)(); #endif short what; } io_event;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | field | what | what | 40 | 40 |  | short | scalar_or_unknown | short what;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 79 | 79 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 88 | 88 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 136 | 136 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 176 | 176 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | dvpoll | dvpoll | 178 | 178 |  |  |  | struct dvpoll
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 182 | 182 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 230 | 230 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 257 | 257 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 263 | 263 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 299 | 299 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 320 | 320 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 338 | 338 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 343 | 343 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 365 | 365 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 474 | 474 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 532 | 532 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 534 | 534 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 559 | 559 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 582 | 582 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 585 | 585 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 586 | 586 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timespec | timespec | 587 | 587 |  |  |  | struct timespec
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 592 | 592 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | kevent | kevent | 829 | 829 |  |  |  | struct kevent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | timeval | timeval | 892 | 892 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.h | struct | timeval | timeval | 53 | 53 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | join_allowed | join_allowed | 77 | 144 |  |  |  | static bool join_allowed(CLIENT *Client, CHANNEL *chan, const char *channame, const char *key)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | join_set_channelmodes | join_set_channelmodes | 153 | 168 |  |  |  | static void join_set_channelmodes(CHANNEL *chan, CLIENT *target, const char *flags)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_TOPIC | IRC_TOPIC | 476 | 569 |  |  |  | GLOBAL bool IRC_TOPIC( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_CHANINFO | IRC_CHANINFO | 664 | 763 |  |  |  | GLOBAL bool IRC_CHANINFO( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHO_Channel | IRC_WHO_Channel | 138 | 194 |  |  |  | static bool IRC_WHO_Channel(CLIENT *Client, CHANNEL *Chan, bool OnlyOps)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHO_Mask | IRC_WHO_Mask | 204 | 284 |  |  |  | static bool IRC_WHO_Mask(CLIENT *Client, char *Mask, bool OnlyOps)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | WHOWAS_EntryWrite | WHOWAS_EntryWrite | 440 | 454 |  |  |  | static bool WHOWAS_EntryWrite(CLIENT *prefix, WHOWAS *entry)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_INFO | IRC_INFO | 539 | 585 |  |  |  | GLOBAL bool IRC_INFO(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_LUSERS | IRC_LUSERS | 685 | 705 |  |  |  | GLOBAL bool IRC_LUSERS( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_MOTD | IRC_MOTD | 749 | 768 |  |  |  | GLOBAL bool IRC_MOTD( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_NAMES | IRC_NAMES | 777 | 846 |  |  |  | GLOBAL bool IRC_NAMES( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_STATS | IRC_STATS | 855 | 976 |  |  |  | GLOBAL bool IRC_STATS( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | struct | list_head | list_head | 864 | 864 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | struct | list_elem | list_elem | 865 | 865 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_TIME | IRC_TIME | 1001 | 1025 |  |  |  | GLOBAL bool IRC_TIME( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_USERHOST | IRC_USERHOST | 1034 | 1071 |  |  |  | GLOBAL bool IRC_USERHOST(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_USERS | IRC_USERS | 1080 | 1087 |  |  |  | GLOBAL bool IRC_USERS(CLIENT * Client, UNUSED REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_VERSION | IRC_VERSION | 1096 | 1128 |  |  |  | GLOBAL bool IRC_VERSION( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_USER | IRC_USER | 420 | 518 |  |  |  | GLOBAL bool IRC_USER(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | Change_Nick | Change_Nick | 901 | 931 |  |  |  | static void Change_Nick(CLIENT *Origin, CLIENT *Target, char *NewNick, bool InformClient)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-metadata.c | function | IRC_METADATA | IRC_METADATA | 42 | 110 |  |  |  | GLOBAL bool IRC_METADATA(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | IRC_MODE | IRC_MODE | 60 | 100 |  |  |  | GLOBAL bool IRC_MODE( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Mode_Limit_Reached | Mode_Limit_Reached | 111 | 120 |  |  |  | static bool Mode_Limit_Reached(CLIENT *Client, int Count)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Channel_Mode_Answer_Request | Channel_Mode_Answer_Request | 383 | 433 |  |  |  | static bool Channel_Mode_Answer_Request(CLIENT *Origin, CHANNEL *Channel)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Channel_Mode | Channel_Mode | 444 | 977 |  |  |  | static bool Channel_Mode(CLIENT *Client, REQUEST *Req, CLIENT *Origin, CHANNEL *Channel)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | IRC_AWAY | IRC_AWAY | 986 | 1006 |  |  |  | GLOBAL bool IRC_AWAY( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Add_To_List | Add_To_List | 1018 | 1072 |  |  |  | static bool Add_To_List(char what, CLIENT *Prefix, CLIENT *Client, CHANNEL *Channel, const char *Pattern)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | struct | list_head | list_head | 1023 | 1023 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | struct | list_head | list_head | 1089 | 1089 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_OPER | IRC_OPER | 65 | 101 |  |  |  | GLOBAL bool IRC_OPER( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | struct | Conf_Oper | Conf_Oper | 68 | 68 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | struct | list_head | list_head | 389 | 389 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | IRC_SetPenalty | IRC_SetPenalty | 541 | 557 |  |  |  | GLOBAL void IRC_SetPenalty(CLIENT *Client, time_t Seconds)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | Get_Prefix | Get_Prefix | 559 | 569 |  |  |  | static const char * Get_Prefix(CLIENT *Target, CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_CheckListTooBig | IRC_CheckListTooBig | 59 | 76 |  |  |  | GLOBAL bool IRC_CheckListTooBig(CLIENT *From, const int Count, const int Limit, const char *Name)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_ERROR | IRC_ERROR | 85 | 120 |  |  |  | GLOBAL bool IRC_ERROR(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 31 | 37 |  |  |  | struct list_elem { struct list_elem *next; /** pointer to next list element */ char mask[MASK_LEN]; /** IRC mask */ char *reason; /** Optional "reason" text */ time_t valid_until; /** 0: unlimited; t(>0): until t */ bool onlyonce; }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | list_elem | list_elem::list_elem | 32 | 32 | list_elem | struct list_elem | structured_object | struct list_elem *next;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem::list_elem | 32 | 32 | list_elem |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | mask | list_elem::mask | 33 | 33 | list_elem | char | scalar_or_unknown | char mask[MASK_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | reason | list_elem::reason | 34 | 34 | list_elem | char | scalar_or_unknown | char *reason;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | valid_until | list_elem::valid_until | 35 | 35 | list_elem | time_t | scalar_or_unknown | time_t valid_until;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | field | onlyonce | list_elem::onlyonce | 36 | 36 | list_elem | bool | scalar_or_unknown | bool onlyonce;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetMask | Lists_GetMask | 45 | 50 |  |  |  | GLOBAL const char * Lists_GetMask(const struct list_elem *e)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 46 | 46 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 59 | 59 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetValidity | Lists_GetValidity | 71 | 76 |  |  |  | GLOBAL time_t Lists_GetValidity(const struct list_elem *e)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 72 | 72 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetOnlyOnce | Lists_GetOnlyOnce | 84 | 89 |  |  |  | GLOBAL bool Lists_GetOnlyOnce(const struct list_elem *e)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 85 | 85 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetFirst | Lists_GetFirst | 97 | 102 |  |  |  | list_elem* Lists_GetFirst(const struct list_head *h)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 98 | 98 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetNext | Lists_GetNext | 110 | 115 |  |  |  | list_elem* Lists_GetNext(const struct list_elem *e)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 111 | 111 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Add | Lists_Add | 126 | 170 |  |  |  | bool Lists_Add(struct list_head *h, const char *Mask, time_t ValidUntil, const char *Reason, bool OnlyOnce)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 127 | 127 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 130 | 130 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 148 | 148 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Unlink | Lists_Unlink | 179 | 194 |  |  |  | static void Lists_Unlink(struct list_head *h, struct list_elem *p, struct list_elem *victim)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 180 | 180 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 180 | 180 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 180 | 180 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Del | Lists_Del | 202 | 223 |  |  |  | GLOBAL void Lists_Del(struct list_head *h, const char *Mask)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 203 | 203 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 205 | 205 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 231 | 231 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 233 | 233 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_CheckDupeMask | Lists_CheckDupeMask | 256 | 267 |  |  |  | list_elem * Lists_CheckDupeMask(const struct list_head *h, const char *Mask )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 257 | 257 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 259 | 259 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Check | Lists_Check | 317 | 321 |  |  |  | bool Lists_Check(struct list_head *h, CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 318 | 318 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_CheckReason | Lists_CheckReason | 332 | 360 |  |  |  | bool Lists_CheckReason(struct list_head *h, CLIENT *Client, char *reason, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 333 | 333 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 335 | 335 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Expire | Lists_Expire | 367 | 398 |  |  |  | GLOBAL void Lists_Expire(struct list_head *h, const char *ListName)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 368 | 368 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 370 | 370 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Count | Lists_Count | 406 | 420 |  |  |  | GLOBAL unsigned long Lists_Count(struct list_head *h)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_head | list_head | 407 | 407 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | struct | list_elem | list_elem | 409 | 409 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 23 | 23 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 25 | 27 |  |  |  | struct list_head { struct list_elem *first; }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | field | list_elem | list_head::list_elem | 26 | 26 | list_head | struct list_elem | structured_object | struct list_elem *first;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_head::list_elem | 26 | 26 | list_head |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 29 | 29 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 30 | 30 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 32 | 32 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 33 | 33 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 35 | 35 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 38 | 38 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 41 | 41 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 42 | 42 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 44 | 44 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 47 | 47 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 48 | 48 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 49 | 49 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_elem | list_elem | 50 | 50 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.h | struct | list_head | list_head | 52 | 52 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | struct | Conf_Channel | Conf_Channel | 223 | 223 |  |  |  | struct Conf_Channel
C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | MatchCaseInsensitiveList | MatchCaseInsensitiveList | 85 | 101 |  |  |  | GLOBAL bool MatchCaseInsensitiveList(const char *Pattern, const char *String, const char *Separator)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | NGIRCd_getNobodyID | NGIRCd_getNobodyID | 573 | 603 |  |  |  | static bool NGIRCd_getNobodyID(uid_t *uid, gid_t *gid )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | struct | passwd | passwd | 576 | 576 |  |  |  | struct passwd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | struct | passwd | passwd | 659 | 659 |  |  |  | struct passwd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | struct | group | group | 660 | 660 |  |  |  | struct group
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_head | list_head | 151 | 151 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_elem | list_elem | 153 | 153 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_head | list_head | 177 | 177 |  |  |  | struct list_head
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | struct | list_elem | list_elem | 178 | 178 |  |  |  | struct list_elem
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | IRC_Num_ENDOFMOTD | IRC_Num_ENDOFMOTD | 258 | 344 |  |  |  | GLOBAL bool IRC_Num_ENDOFMOTD(CLIENT * Client, UNUSED REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | IRC_Num_ISUPPORT | IRC_Num_ISUPPORT | 349 | 379 |  |  |  | GLOBAL bool IRC_Num_ISUPPORT(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | struct | _NUMERIC | _NUMERIC | 49 | 52 |  |  |  | struct _NUMERIC { int numeric; bool (*function) PARAMS(( CLIENT *Client, REQUEST *Request )); }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | field | numeric | _NUMERIC::numeric | 50 | 50 | _NUMERIC | int | scalar_or_unknown | int numeric;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | field | function | _NUMERIC::function | 51 | 51 | _NUMERIC | bool | scalar_or_unknown | bool (*function)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | field | PARAMS | _NUMERIC::PARAMS | 51 | 51 | _NUMERIC | PARAMS | scalar_or_unknown | PARAMS(( CLIENT *Client, REQUEST *Request ));
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | struct | _NUMERIC | _NUMERIC | 420 | 420 |  |  |  | struct _NUMERIC
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | struct | _REQUEST | _REQUEST | 23 | 29 |  |  |  | struct _REQUEST { char *prefix; /**< Prefix */ char *command; /**< IRC command */ char *argv[15]; /**< Parameters, at most 15 (0..14) */ int argc; /**< Number of given parameters */ }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | typedef | REQUEST | REQUEST | 23 | 29 |  |  |  | typedef struct _REQUEST { char *prefix; /**< Prefix */ char *command; /**< IRC command */ char *argv[15]; /**< Parameters, at most 15 (0..14) */ int argc; /**< Number of given parameters */ } REQUEST;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | prefix | _REQUEST::prefix | 25 | 25 | _REQUEST | char | scalar_or_unknown | char *prefix;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | command | _REQUEST::command | 26 | 26 | _REQUEST | char | scalar_or_unknown | char *command;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | argv | _REQUEST::argv | 27 | 27 | _REQUEST | char | scalar_or_unknown | char *argv[15];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | argc | _REQUEST::argc | 28 | 28 | _REQUEST | int | scalar_or_unknown | int argc;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | struct | _COMMAND | _COMMAND | 32 | 43 |  |  |  | struct _COMMAND { const char *name; /**< Command name */ bool (*function) PARAMS(( CLIENT *Client, REQUEST *Request )); /**< Function to handle this command */ CLIENT_TYPE type; /**< Valid client types (bit mask) */ int min_argc; /**< Min parameters */ int max_argc; /**< Max parameters */ int penalt
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | typedef | COMMAND | COMMAND | 32 | 43 |  |  |  | typedef struct _COMMAND { const char *name; /**< Command name */ bool (*function) PARAMS(( CLIENT *Client, REQUEST *Request )); /**< Function to handle this command */ CLIENT_TYPE type; /**< Valid client types (bit mask) */ int min_argc; /**< Min parameters */ int max_argc; /**< Max parameters */ in
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | name | _COMMAND::name | 34 | 34 | _COMMAND | char | scalar_or_unknown | const char *name;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | function | _COMMAND::function | 35 | 35 | _COMMAND | bool | scalar_or_unknown | bool (*function)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | PARAMS | _COMMAND::PARAMS | 35 | 35 | _COMMAND | PARAMS | scalar_or_unknown | PARAMS(( CLIENT *Client, REQUEST *Request ));
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | type | _COMMAND::type | 37 | 37 | _COMMAND | CLIENT_TYPE | scalar_or_unknown | CLIENT_TYPE type;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | min_argc | _COMMAND::min_argc | 38 | 38 | _COMMAND | int | scalar_or_unknown | int min_argc;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | max_argc | _COMMAND::max_argc | 39 | 39 | _COMMAND | int | scalar_or_unknown | int max_argc;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | penalty | _COMMAND::penalty | 40 | 40 | _COMMAND | int | scalar_or_unknown | int penalty;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | lcount | _COMMAND::lcount | 41 | 41 | _COMMAND | long | scalar_or_unknown | long lcount, rcount;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.h | field | bytes | _COMMAND::bytes | 42 | 42 | _COMMAND | long | scalar_or_unknown | long bytes;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | struct | _Proc_Stat | _Proc_Stat | 21 | 24 |  |  |  | struct _Proc_Stat { pid_t pid; /**< PID of the child process or 0 if none */ int pipe_fd; /**< Pipe file descriptor or -1 if none */ }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | typedef | PROC_STAT | PROC_STAT | 21 | 24 |  |  |  | typedef struct _Proc_Stat { pid_t pid; /**< PID of the child process or 0 if none */ int pipe_fd; /**< Pipe file descriptor or -1 if none */ } PROC_STAT;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | field | pid | _Proc_Stat::pid | 22 | 22 | _Proc_Stat | pid_t | scalar_or_unknown | pid_t pid;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.h | field | pipe_fd | _Proc_Stat::pipe_fd | 23 | 23 | _Proc_Stat | int | scalar_or_unknown | int pipe_fd;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | sockaddr | sockaddr | 181 | 181 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | sockaddr_in | sockaddr_in | 191 | 191 |  |  |  | struct sockaddr_in
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | sockaddr_in | sockaddr_in | 191 | 191 |  |  |  | struct sockaddr_in
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | hostent | hostent | 192 | 192 |  |  |  | struct hostent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | addrinfo | addrinfo | 239 | 239 |  |  |  | struct addrinfo
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | addrinfo | addrinfo | 240 | 240 |  |  |  | struct addrinfo
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | hostent | hostent | 274 | 274 |  |  |  | struct hostent
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | struct | in_addr | in_addr | 288 | 288 |  |  |  | struct in_addr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr_un | sockaddr_un | 383 | 383 |  |  |  | struct sockaddr_un
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr_un | sockaddr_un | 414 | 414 |  |  |  | struct sockaddr_un
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr_un | sockaddr_un | 431 | 431 |  |  |  | struct sockaddr_un
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT8 | UINT8 | 73 | 73 |  |  |  | typedef uint8_t UINT8;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT16 | UINT16 | 74 | 74 |  |  |  | typedef uint16_t UINT16;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT32 | UINT32 | 75 | 75 |  |  |  | typedef uint32_t UINT32;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT8 | UINT8 | 77 | 77 |  |  |  | typedef unsigned char UINT8;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT16 | UINT16 | 78 | 78 |  |  |  | typedef unsigned short UINT16;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | UINT32 | UINT32 | 79 | 79 |  |  |  | typedef unsigned int UINT32;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | <anonymous> | <anonymous> | 85 | 85 |  |  |  | typedef unsigned char bool;
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | struct | timeval | timeval | 139 | 139 |  |  |  | struct timeval
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | struct | _code | _code | 167 | 170 |  |  |  | struct _code { char *c_name; int c_val; }
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | typedef | CODE | CODE | 167 | 170 |  |  |  | typedef struct _code { char *c_name; int c_val; } CODE;
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | field | c_name | _code::c_name | 168 | 168 | _code | char | scalar_or_unknown | char *c_name;
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | field | c_val | _code::c_val | 169 | 169 | _code | int | scalar_or_unknown | int c_val;
```

## Component: Network / Communication / Protocol
- Category: technical
- Assigned symbols: 273

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_setport | ng_ipaddr_setport | 80 | 105 | Function responsible for setting the port number for the IP address binding in the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_ipequal | ng_ipaddr_ipequal | 109 | 130 | Implements IP address equality comparison logic for network packet validation. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_tostr | ng_ipaddr_tostr | 134 | 143 | Converts an IP address structure into a string representation for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_tostr_r | ng_ipaddr_tostr_r | 147 | 175 | Converts an IP address structure into a string representation for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_af | ng_ipaddr_af | 49 | 59 | Implements the Address Family (AF) function for IPv4 and IPv6 address handling within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_salen | ng_ipaddr_salen | 62 | 73 | Calculates the socket address length for an IPv4 address structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_getport | ng_ipaddr_getport | 76 | 92 | Function to retrieve the port number from an IP address structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_tostr | ng_ipaddr_tostr | 116 | 121 | Converts an IP address structure into a string representation for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_tostr_r | ng_ipaddr_tostr_r | 123 | 130 | Converts an IP address structure into a string representation for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Join | Channel_Join | 250 | 283 | Handles the logic for joining a new channel within the IRC server's network communication stack. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Kick | Channel_Kick | 331 | 420 | Handles the logic for kicking a channel member from an IRC network connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Quit | Channel_Quit | 423 | 443 | Handles the logic for disconnecting a client from a channel, including sending quit messages and managing channel state transitions. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_NextChannelOf | Channel_NextChannelOf | 617 | 623 | Handles channel state transitions and client-to-channel mapping for IRC protocol messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetClient | Channel_GetClient | 626 | 631 | Handles the retrieval of client information from the channel context within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserModeAdd | Channel_UserModeAdd | 707 | 732 | Handles channel user mode addition for IRC client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Can_Send_To_Channel | Can_Send_To_Channel | 922 | 970 | Validates channel permissions and determines if a client is allowed to send messages to a specific channel. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Write | Channel_Write | 973 | 994 | Handles the transmission of channel data and commands over the network connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Remove_Client | Remove_Client | 1071 | 1158 | Handles the removal of a client from the channel list during server initialization or reconfiguration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_AddExcept | Channel_AddExcept | 1170 | 1176 | Handles channel membership management and permission filtering for IRC client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | ShowChannelList | ShowChannelList | 1188 | 1210 | Handles channel list retrieval and display for IRC clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_CapAdd | Client_CapAdd | 47 | 56 | Handles client capability registration and management for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_CapDel | Client_CapDel | 58 | 67 | Handles the deletion of client capabilities, likely managing protocol state or connection attributes. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ThisServer | Client_ThisServer | 129 | 133 | Handles the creation and management of the local client connection to the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NewLocal | Client_NewLocal | 140 | 145 | Handles the creation and initialization of a new local client connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NewRemoteServer | Client_NewRemoteServer | 152 | 158 | Handles the creation and management of a new remote server connection within the client application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NewRemoteUser | Client_NewRemoteUser | 165 | 171 | Handles the creation and management of remote user connections within the client communication layer. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Destroy | Client_Destroy | 227 | 322 | Handles the destruction of an IRC client connection and manages associated message forwarding. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetHostname | Client_SetHostname | 334 | 359 | Handles the server's hostname configuration for client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetIPAText | Client_SetIPAText | 368 | 380 | Handles the transmission of IP address and text data to the client over the network connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetID | Client_SetID | 383 | 398 | Handles client identification and connection setup for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetUser | Client_SetUser | 401 | 417 | Handles client authentication and identity verification for IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetInfo | Client_SetInfo | 440 | 452 | Handles client connection state and information exchange during the IRC handshake and connection lifecycle. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetModes | Client_SetModes | 455 | 462 | Handles client mode configuration and protocol-level client state management. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetFlags | Client_SetFlags | 465 | 472 | Handles client connection flags and state management for the IRC client interface. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetAway | Client_SetAway | 491 | 506 | Handles client connection state and disconnection events for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetType | Client_SetType | 509 | 516 | Handles client connection types and protocol negotiation for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetHops | Client_SetHops | 519 | 524 | Manages the hop count for client connections, a key parameter in IRC protocol configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetToken | Client_SetToken | 527 | 532 | Handles token authentication and client identity verification for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetIntroducer | Client_SetIntroducer | 535 | 541 | Handles the introduction of a client to the server, likely managing the connection handshake or initial peer identification. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ModeAdd | Client_ModeAdd | 544 | 562 | Handles client connection state and mode transitions for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ModeDel | Client_ModeDel | 565 | 589 | Handles client connection state transitions and mode negotiation for the IRC client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Search | Client_Search | 597 | 620 | Handles client connection logic and nickname lookup for IRC client communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SearchServer | Client_SearchServer | 631 | 652 | Handles client connection logic and server search functionality for establishing relay connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_GetFromToken | Client_GetFromToken | 659 | 677 | Handles token parsing and client connection logic for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Conn | Client_Conn | 688 | 693 | Handles the connection establishment and management between the ngIRCd client and the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_User | Client_User | 717 | 722 | Handles client connection and user session management for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Hostname | Client_Hostname | 746 | 751 | Function responsible for retrieving and returning the client's hostname, a key component of the IRC client's network identity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HostnameCloaked | Client_HostnameCloaked | 758 | 763 | Function responsible for handling client hostname encryption and transmission. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_IPAText | Client_IPAText | 790 | 803 | Function responsible for formatting client IP address text for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Hops | Client_Hops | 870 | 875 | Implements the logic for calculating the number of hops required for a client to reach the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Token | Client_Token | 878 | 883 | Handles client authentication and token validation for IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyToken | Client_MyToken | 886 | 891 | Handles client token authentication and communication with the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NextHop | Client_NextHop | 894 | 906 | Handles network hop selection and connection management for the client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Mask | Client_Mask | 917 | 931 | Handles client connection masking and protocol-specific client identification logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MaskCloaked | Client_MaskCloaked | 945 | 960 | Handles the masking and unmasking of client identifiers during connection establishment. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Introducer | Client_Introducer | 963 | 968 | Handles the initialization and connection setup for the client side of the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_TopServer | Client_TopServer | 971 | 976 | Handles the top-level server connection and client communication logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Away | Client_Away | 995 | 1000 | Handles client disconnection and manages the state of the client connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_CheckID | Client_CheckID | 1059 | 1092 | Validates the identity of an IRC client connection by checking the provided ID string. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_First | Client_First | 1095 | 1099 | Handles the creation and management of the first client connection to the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Next | Client_Next | 1102 | 1107 | Handles client connection state transitions and manages the lifecycle of an active IRC client session. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_GetWhowas | Client_GetWhowas | 1244 | 1248 | Handles the retrieval of client identity information for IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Reject | Client_Reject | 1286 | 1303 | Handles client connection termination and rejection logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_RegisterWhowas | Client_RegisterWhowas | 1480 | 1515 | Handles client registration and connection management for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | cb_introduceClient | cb_introduceClient | 1595 | 1602 | Handles client connection initialization and introduces the client to the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Announce | Client_Announce | 1615 | 1692 | Handles client-to-server announcements and message broadcasting logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_SetEncoding | Conn_SetEncoding | 45 | 76 | Handles the encoding and decoding of connection data for the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_UnsetEncoding | Conn_UnsetEncoding | 83 | 97 | Handles the removal of encoding settings for connection objects. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Convert_Message | Convert_Message | 109 | 130 | Converts message data using the iconv library to handle character set translation for legacy clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_EncodingFrom | Conn_EncodingFrom | 148 | 159 | Handles the encoding and decoding of connection messages for the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_EncodingTo | Conn_EncodingTo | 175 | 186 | Handles protocol encoding and decoding for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_UpdateIdle | Conn_UpdateIdle | 35 | 40 | Handles connection state and idle timeout management for IRC network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_UpdatePing | Conn_UpdatePing | 51 | 56 | Handles connection state updates and ping responses for the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_GetSignon | Conn_GetSignon | 61 | 66 | Handles connection initialization and authentication logic for establishing a network session. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_GetIdle | Conn_GetIdle | 68 | 74 | Handles connection state and idle timeout management for network sockets. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_LastPing | Conn_LastPing | 76 | 81 | Handles network connection state and ping interval management for IRC client communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SetPenalty | Conn_SetPenalty | 94 | 120 | Handles connection state and penalty settings for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_ClearFlags | Conn_ClearFlags | 122 | 128 | Handles clearing of connection flags and related state within the network connection layer. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_Flag | Conn_Flag | 130 | 135 | Handles connection flags and connection ID management for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SetFlag | Conn_SetFlag | 137 | 142 | Handles connection flags and state management for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_First | Conn_First | 144 | 154 | Handles connection initialization and global connection ID assignment for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_Next | Conn_Next | 156 | 168 | Handles network connection management and ID tracking for IRC server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_Options | Conn_Options | 170 | 175 | Defines the global connection options structure used for managing network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SetOption | Conn_SetOption | 180 | 185 | Handles connection initialization and configuration options for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_StartTime | Conn_StartTime | 192 | 205 | Implements the connection start time calculation for IRC client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SendQ | Conn_SendQ | 210 | 220 | Handles network connection sending and queue management for IRC messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SendMsg | Conn_SendMsg | 225 | 231 | Handles the transmission of messages over the network connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SendBytes | Conn_SendBytes | 237 | 242 | Handles the transmission of data over the network connection using the specified connection ID. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_RecvQ | Conn_RecvQ | 247 | 257 | Handles incoming connection requests and manages the queue for receiving network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_RecvMsg | Conn_RecvMsg | 262 | 267 | Handles incoming network messages and manages the connection state for receiving data. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_RecvBytes | Conn_RecvBytes | 273 | 278 | Handles network connection logic and data reception for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_IPA | Conn_IPA | 283 | 288 | Handles IP address lookup and connection initialization for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_ResetWCounter | Conn_ResetWCounter | 290 | 294 | Handles connection reset and counter reset logic for the network connection state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_WCounter | Conn_WCounter | 296 | 300 | Implements connection counter logic for tracking active network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | openreadclose | openreadclose | 91 | 131 | SSL/TLS connection handling and certificate management for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | Verify_openssl | Verify_openssl | 211 | 231 | SSL/TLS certificate verification logic for secure client-server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Free | ConnSSL_Free | 306 | 345 | Frees a SSL connection object, managing the lifecycle of secure network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_InitLibrary | ConnSSL_InitLibrary | 348 | 459 | Initializes the SSL/TLS library connection for secure communication between the server and clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_SetVerifyProperties_gnutls | ConnSSL_SetVerifyProperties_gnutls | 463 | 494 | Implements SSL/TLS verification properties for secure client-server connections using the GnuTLS library. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_LoadServerKey_gnutls | ConnSSL_LoadServerKey_gnutls | 497 | 577 | SSL/TLS key loading function for secure server connections using the GnuTLS library. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_LoadServerKey_openssl | ConnSSL_LoadServerKey_openssl | 582 | 621 | SSL/TLS key loading function for secure server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_SetVerifyProperties_openssl | ConnSSL_SetVerifyProperties_openssl | 624 | 671 | SSL/TLS certificate verification configuration handler for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Init_SSL | ConnSSL_Init_SSL | 675 | 741 | SSL/TLS connection initialization and handshake setup for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_PrepareConnect | ConnSSL_PrepareConnect | 744 | 785 | SSL/TLS connection preparation logic for establishing secure client-server links. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_HandleError | ConnSSL_HandleError | 803 | 883 | Handles SSL/TLS connection errors and manages the lifecycle of secure network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_LogCertInfo | ConnSSL_LogCertInfo | 938 | 1082 | SSL/TLS connection handling and certificate information logging for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Accept | ConnSSL_Accept | 1092 | 1109 | SSL/TLS connection handling and certificate acceptance logic for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Connect | ConnSSL_Connect | 1112 | 1121 | Handles SSL/TLS connection establishment and handshake for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_InitCertFp | ConnSSL_InitCertFp | 1123 | 1196 | SSL certificate initialization function for secure connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnectAccept | ConnectAccept | 1199 | 1224 | Handles SSL/TLS connection establishment and acceptance for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Write | ConnSSL_Write | 1227 | 1246 | SSL/TLS connection handling and data transmission for secure IRC communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Read | ConnSSL_Read | 1249 | 1271 | SSL/TLS connection handling and data reading for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_GetCipherInfo | ConnSSL_GetCipherInfo | 1274 | 1308 | SSL/TLS cipher information retrieval for secure client-server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_GetCertFp | ConnSSL_GetCertFp | 1310 | 1314 | SSL certificate retrieval function for secure connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_SetCertFp | ConnSSL_SetCertFp | 1316 | 1322 | SSL certificate fingerprint handling for secure client-server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_InitLibrary | ConnSSL_InitLibrary | 1325 | 1329 | Initializes the SSL/TLS library connection for secure communication with IRC servers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_InitConn | Zip_InitConn | 38 | 75 | Initializes a connection object for the network protocol, handling the setup of connection parameters and state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_Buffer | Zip_Buffer | 90 | 114 | Handles network data buffering and transmission for connection management. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_Flush | Zip_Flush | 124 | 182 | Handles network protocol operations for the connection, specifically managing the flushing of compressed data buffers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Unzip_Buffer | Unzip_Buffer | 193 | 253 | Handles decompression and buffer management for network data streams. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_SendBytes | Zip_SendBytes | 260 | 265 | Handles the transmission of binary data over the network connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_RecvBytes | Zip_RecvBytes | 272 | 277 | Handles network protocol data transfer for receiving compressed bytes over a connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_listen | cb_listen | 166 | 171 | Handles incoming network connections and socket initialization for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_connserver | cb_connserver | 179 | 248 | Handles connection server callbacks for incoming client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | server_login | server_login | 255 | 271 | Handles the connection establishment and login process for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_clientserver | cb_clientserver | 279 | 302 | Handles client-server socket connections and manages the communication protocol between the server and clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Init | Conn_Init | 307 | 324 | Initializes the connection object and sets up the initial network state for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Exit | Conn_Exit | 329 | 348 | Handles the cleanup and exit of an IRC connection, managing socket teardown and resource release. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_CloseAllSockets | Conn_CloseAllSockets | 355 | 365 | Handles the closing of all network sockets to free resources. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Init_Listeners | Init_Listeners | 375 | 403 | Initializes the server's listener infrastructure for incoming connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_InitListeners | Conn_InitListeners | 410 | 522 | Initializes network listeners for the connection handling subsystem. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 434 | 434 | Defines the sockaddr structure used for network address handling and socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | InitSinaddrListenAddr | InitSinaddrListenAddr | 561 | 574 | Initializes the listening socket address for incoming connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | set_v6_only | set_v6_only | 584 | 599 | Function that restricts IPv6 socket usage based on the specified address family. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | NewListener | NewListener | 608 | 655 | Handles the creation of network listeners for incoming IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 631 | 631 | Defines the sockaddr structure used for network address handling and socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Handler | Conn_Handler | 666 | 815 | Handles connection initialization and management for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Password | Conn_Password | 915 | 923 | Function responsible for handling password authentication and establishing secure connections to the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetPassword | Conn_SetPassword | 925 | 938 | Handles password authentication for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Write | Conn_Write | 948 | 1021 | Handles network connection writing and data transmission over the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Close | Conn_Close | 1034 | 1181 | Handles closing of network connections and manages associated message forwarding. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Count | Conn_Count | 1188 | 1192 | Implements the connection count metric for tracking active network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_CountAccepted | Conn_CountAccepted | 1210 | 1214 | Handles connection counting for established client sessions. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetIPAInfo | Conn_GetIPAInfo | 1253 | 1258 | Retrieves IP address and port information for a connection identified by the given ID. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Handle_Write | Handle_Write | 1266 | 1336 | Handles writing data to a network connection, managing the socket or channel interface for IRC traffic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Count_Connections | Count_Connections | 1343 | 1356 | Handles connection counting logic for IRC client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | New_Connection | New_Connection | 1365 | 1491 | Handles the creation and initialization of new network connections for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 1382 | 1382 | Defines the sockaddr structure used for network address handling and socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_StartLogin | Conn_StartLogin | 1498 | 1539 | Handles the initialization and connection setup for the IRC client within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Account_Connection | Account_Connection | 1544 | 1553 | Handles the connection and authentication logic for user accounts within the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Socket2Index | Socket2Index | 1562 | 1587 | Handles socket indexing and connection management for the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Read_Request | Read_Request | 1595 | 1710 | Handles incoming connection requests and manages the initial handshake with clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Handle_Buffer | Handle_Buffer | 1722 | 1889 | Handles buffer management for network connections, likely involved in data transmission or protocol framing. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Check_Connections | Check_Connections | 1896 | 1950 | Handles connection establishment, teardown, and state management for IRC client and server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Check_Servers | Check_Servers | 1955 | 2000 | Function responsible for checking and validating server connections and network endpoints. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | New_Server | New_Server | 2008 | 2129 | Handles the creation and initialization of a new server connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 2057 | 2057 | Defines the sockaddr structure used for network address handling and socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 2065 | 2065 | Defines the sockaddr structure used for network address handling and socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Init_Socket | Init_Socket | 2163 | 2198 | Initializes network sockets for establishing IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_Connect_to_Server | cb_Connect_to_Server | 2207 | 2261 | Handles the connection establishment and socket communication with remote IRC servers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_Read_Resolver_Result | cb_Read_Resolver_Result | 2270 | 2382 | Handles socket I/O and connection event callbacks for resolving DNS records. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Simple_Message | Simple_Message | 2394 | 2415 | Handles low-level socket communication and message parsing for IRC protocol data. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetClient | Conn_GetClient | 2425 | 2434 | Retrieves a global client connection object from the connection index. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetProcStat | Conn_GetProcStat | 2442 | 2451 | Retrieves statistics for a specific connection, likely used for monitoring connection health or performance metrics. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetFromProc | Conn_GetFromProc | 2459 | 2471 | Handles connection initialization and retrieval from a process, managing the connection ID and file descriptor for network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Throttle_Connection | Throttle_Connection | 2481 | 2501 | Implements connection throttling logic to manage client connection rates and prevent abuse. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetAuthPing | Conn_GetAuthPing | 2505 | 2510 | Handles authentication and ping requests for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetAuthPing | Conn_SetAuthPing | 2512 | 2517 | Handles authentication and ping requests for the connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_clientserver_ssl | cb_clientserver_ssl | 2529 | 2552 | SSL/TLS client-server connection handler for secure networking. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_listen_ssl | cb_listen_ssl | 2561 | 2571 | SSL/TLS connection listener callback handler for secure socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_connserver_login_ssl | cb_connserver_login_ssl | 2586 | 2630 | Handles SSL/TLS authentication and connection establishment for server login. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | SSL_WantRead | SSL_WantRead | 2650 | 2658 | Handles SSL/TLS socket read operations for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | SSL_WantWrite | SSL_WantWrite | 2668 | 2676 | Handles SSL/TLS socket write operations for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetCipherInfo | Conn_GetCipherInfo | 2686 | 2693 | Retrieves cipher information for a connection, supporting SSL/TLS encryption for secure communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_UsesSSL | Conn_UsesSSL | 2701 | 2708 | Function that determines whether SSL/TLS encryption is enabled for the connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_UsesSSL | Conn_UsesSSL | 2730 | 2734 | Function that determines whether SSL/TLS encryption is enabled for the connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_get | io_event_get | 159 | 171 | Handles low-level socket I/O and event loop management for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_devpoll | io_dispatch_devpoll | 175 | 208 | Handles network I/O dispatching for device polling in the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_devpoll | io_event_change_devpoll | 211 | 225 | Handles low-level I/O events and device polling for network socket communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 214 | 214 | Represents the pollfd structure used for managing network I/O events in the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_poll | io_dispatch_poll | 256 | 294 | Handles network I/O operations and socket polling for IRC protocol communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_poll | io_event_change_poll | 296 | 315 | Handles network I/O events and socket communication for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_poll | io_close_poll | 317 | 333 | Handles socket I/O and connection lifecycle management for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_select | io_dispatch_select | 364 | 400 | Handles network socket dispatching and I/O operations for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_select | io_close_select | 426 | 447 | Handles socket file descriptor management and low-level network I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_epoll | io_event_change_epoll | 459 | 471 | Handles network event handling and socket I/O operations for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | epoll_event | epoll_event | 462 | 462 | Represents the data structure used to manage network socket connections and I/O events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_epoll | io_dispatch_epoll | 473 | 501 | Handles network I/O dispatching for the server using the epoll event loop. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | epoll_event | epoll_event | 478 | 478 | Defines the data structure used to represent network connection events managed by the epoll subsystem. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_kqueue | io_event_change_kqueue | 556 | 579 | Handles low-level I/O event handling and socket communication for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_kqueue | io_dispatch_kqueue | 581 | 628 | Handles network I/O dispatching for the IRC server using the Kqueue system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_setcb | io_event_setcb | 686 | 695 | Handles low-level socket I/O event callbacks for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | backend_create_ev | backend_create_ev | 698 | 719 | Handles low-level socket and event loop management for backend connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_create | io_event_create | 722 | 751 | Handles low-level socket I/O and event creation for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_add | io_event_add | 754 | 792 | Handles low-level socket I/O and event registration for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close | io_close | 822 | 851 | Handles the closing of network file descriptors for IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_del | io_event_del | 854 | 888 | Handles network event delivery and socket I/O operations for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch | io_dispatch | 891 | 911 | Handles network I/O operations and socket dispatching for the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_docallback | io_docallback | 915 | 927 | Handles low-level I/O operations and socket communication for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_LS | Handle_CAP_LS | 118 | 128 | Handles the parsing and processing of client capability (LS) requests from the IRC client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_LIST | Handle_CAP_LIST | 137 | 144 | Handles the parsing and management of client capability lists for IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_REQ | Handle_CAP_REQ | 153 | 172 | Handles client requests for capability information, likely involving protocol negotiation or server-side capability declarations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_ACK | Handle_CAP_ACK | 181 | 188 | Handles the ACK response for client capability requests within the IRC protocol stack. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_CLEAR | Handle_CAP_CLEAR | 196 | 209 | Handles the clearing of client capabilities, likely managing protocol state or connection attributes. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_END | Handle_CAP_END | 217 | 233 | Handles the end of a client connection and manages the final state of the IRC client session. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | IRC_CAP | IRC_CAP | 244 | 274 | Handles the definition and management of IRC capability flags for client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | part_from_all_channels | part_from_all_channels | 53 | 65 | Handles the parsing and routing of IRC channel data from the client to the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | cb_join_forward | cb_join_forward | 183 | 204 | Handles client connection logic and channel join forwarding for IRC communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | join_forward | join_forward | 217 | 248 | Handles the logic for forwarding a channel join request to a target client within the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_Send_Channel_Info | IRC_Send_Channel_Info | 256 | 282 | Handles the transmission of channel information to clients via the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_JOIN | IRC_JOIN | 291 | 428 | Handles the logic for joining an IRC channel, managing client connections, and processing incoming join requests. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_PART | IRC_PART | 437 | 467 | Handles the parsing of IRC channel requests and responses to manage client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_LIST | IRC_LIST | 578 | 655 | Handles the creation and management of IRC channels within the server's network communication stack. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-encoding.c | function | IRC_CHARCONV | IRC_CHARCONV | 41 | 58 | Handles character set conversion for legacy clients, implementing the IRC character encoding protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHOIS_SendReply | IRC_WHOIS_SendReply | 294 | 438 | Handles the sending of WHOIS replies to clients via the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_ISON | IRC_ISON | 594 | 623 | Function that handles IRC protocol requests and responses for the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_LINKS | IRC_LINKS | 632 | 676 | Handles the creation and management of IRC connection links between clients and the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_SERVLIST | IRC_SERVLIST | 714 | 740 | Handles the retrieval and management of IRC server lists for client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_SUMMON | IRC_SUMMON | 985 | 992 | Handles the IRC server's command protocol for summoning clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHO | IRC_WHO | 1137 | 1176 | Handles IRC client connection requests and manages WHOIS information retrieval. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHOIS | IRC_WHOIS | 1185 | 1285 | Implements the WHOIS command handler for IRC client communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHOWAS | IRC_WHOWAS | 1294 | 1373 | Handles the IRC WHOIS request/response protocol interaction between the server and clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Send_LUSERS | IRC_Send_LUSERS | 1381 | 1445 | Handles the transmission of user list data to the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Send_NAMES | IRC_Send_NAMES | 1496 | 1561 | Handles the transmission of channel names to clients via the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Send_ISUPPORT | IRC_Send_ISUPPORT | 1568 | 1583 | Handles the transmission of server capabilities (ISUPPORT) to clients via the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_SVSNICK | IRC_SVSNICK | 375 | 411 | Handles the SVSNICK protocol for client connection and authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_WEBIRC | IRC_WEBIRC | 618 | 637 | Handles the connection and authentication logic for the IRC web interface. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_QUIT | IRC_QUIT | 646 | 693 | Handles client disconnection and request termination for the IRC protocol. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_QUIT_HTTP | IRC_QUIT_HTTP | 707 | 713 | Handles HTTP-based client disconnection requests and manages the protocol for terminating IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_PING | IRC_PING | 724 | 789 | Handles the IRC PING request-response protocol to maintain client connectivity. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_PONG | IRC_PONG | 798 | 892 | Handles the server's response to client connection attempts, managing the state of the connection and sending acknowledgment data. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Send_ListChange | Send_ListChange | 1128 | 1152 | Handles network protocol logic for sending channel list changes to clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-op.c | function | try_kick | try_kick | 35 | 47 | Handles IRC channel operations including user kicking, which involves managing client connections and network messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-op.c | function | IRC_KICK | IRC_KICK | 58 | 125 | Handles the logic for sending a kick command to a client over the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-op.c | function | IRC_INVITE | IRC_INVITE | 134 | 236 | Handles the logic for sending and receiving invite messages over the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_REHASH | IRC_REHASH | 150 | 168 | Handles the rehashing of IRC client connections and requests within the server's network stack. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_CONNECT | IRC_CONNECT | 202 | 294 | Handles the connection establishment and handshake between the client and the IRC server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_DISCONNECT | IRC_DISCONNECT | 306 | 338 | Handles the disconnection of an IRC client and manages the associated request/response lifecycle. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_WALLOPS | IRC_WALLOPS | 347 | 375 | Handles IRC wall messages and client requests within the IRC protocol stack. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_xLINE | IRC_xLINE | 384 | 480 | Handles network protocol requests for XLINE (X-Link) commands between the client and server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-server.c | function | IRC_SERVER | IRC_SERVER | 49 | 255 | Handles the initialization and connection setup for the IRC server, managing the client-socket interaction. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-server.c | function | IRC_NJOIN | IRC_NJOIN | 264 | 376 | Handles the network protocol for joining a chat channel, managing client connections and request/response interactions. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-server.c | function | IRC_SQUIT | IRC_SQUIT | 385 | 475 | Handles the SQUIT command to terminate the connection between the client and the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | IRC_WriteStrServersPrefixFlag_CB | IRC_WriteStrServersPrefixFlag_CB | 388 | 404 | Handles network protocol logic for server prefix flags during client connection establishment. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | cb_writeStrServersPrefixFlag | cb_writeStrServersPrefixFlag | 571 | 575 | Handles network protocol logic for writing server prefix flags to client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | Send_Marked_Connections | Send_Marked_Connections | 583 | 601 | Handles the transmission of marked connection data over the network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_KILL | IRC_KILL | 138 | 179 | Handles the IRC protocol command to terminate a client connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_NOTICE | IRC_NOTICE | 188 | 192 | Handles network protocol signaling and client connection events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_PRIVMSG | IRC_PRIVMSG | 201 | 205 | Handles the transmission of private message requests to the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_SQUERY | IRC_SQUERY | 214 | 218 | Handles client-to-server query requests for IRC channel information. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_HELP | IRC_HELP | 304 | 331 | Handles client-to-server communication by providing a helper function to send IRC help messages. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_KillClient | IRC_KillClient | 348 | 412 | Handles client disconnection and cleanup of IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | Send_Message_Mask | Send_Message_Mask | 791 | 847 | Handles the transmission of chat messages to IRC clients over the network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | Login_Autojoin | Login_Autojoin | 219 | 240 | Handles the client connection and authentication handshake for joining the IRC network. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | Match | Match | 50 | 57 | Handles pattern matching logic for IRC channel names and user identifiers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | Matche | Matche | 103 | 131 | Handles pattern matching logic for IRC channel and user identifiers within the server's core networking stack. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | Matche_After_Star | Matche_After_Star | 133 | 180 | Function implementing pattern matching logic for IRC message parsing. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Announce_Channel | Announce_Channel | 39 | 112 | Handles the logic for announcing a channel to the IRC network, likely involving packet construction and transmission. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Announce_Server | Announce_Server | 119 | 143 | Handles server announcement logic for client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Send_List | Send_List | 150 | 165 | Handles the transmission of channel data over the network using the specified data structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Synchronize_Lists | Synchronize_Lists | 173 | 207 | Handles synchronization of client lists during connection establishment or reconnection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Send_CHANINFO | Send_CHANINFO | 214 | 249 | Handles network protocol logic for sending channel information to clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\op.c | function | Op_Check | Op_Check | 66 | 92 | Handles client connection requests and validates incoming network data structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Parse_Request | Parse_Request | 175 | 268 | Handles parsing of incoming network requests to determine the type of data to process. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | ScrubCTCP | ScrubCTCP | 582 | 609 | Handles the parsing and scrubbing of CTCP (Control and Status Protocol) messages for IRC server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Resolve_Addr_Ident | Resolve_Addr_Ident | 57 | 79 | Handles address resolution and identification for IRC connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Resolve_Name | Resolve_Name | 85 | 107 | Handles name resolution and host lookup for IRC server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Do_IdentQuery | Do_IdentQuery | 132 | 158 | Handles the resolution of client identifiers and associated address information for IRC connection establishment. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | ReverseLookup | ReverseLookup | 170 | 217 | Implements reverse lookup logic for resolving IP addresses to hostnames or vice versa. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Addr_in_list | Addr_in_list | 295 | 324 | Handles address resolution and IP address validation for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Do_ResolveAddr_Ident | Do_ResolveAddr_Ident | 358 | 407 | Handles the resolution of address identifiers and socket connections for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Do_ResolveName | Do_ResolveName | 410 | 450 | Handles name resolution and connection setup for IRC server clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr | sockaddr | 430 | 430 | Defines the sockaddr structure used for network address handling in the server. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_setport | ng_ipaddr_setport | 80 | 105 |  |  |  | GLOBAL void ng_ipaddr_setport(ng_ipaddr_t *a, UINT16 port)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_ipequal | ng_ipaddr_ipequal | 109 | 130 |  |  |  | GLOBAL bool ng_ipaddr_ipequal(const ng_ipaddr_t *a, const ng_ipaddr_t *b)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_tostr | ng_ipaddr_tostr | 134 | 143 |  |  |  | GLOBAL const char * ng_ipaddr_tostr(const ng_ipaddr_t *addr)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_tostr_r | ng_ipaddr_tostr_r | 147 | 175 |  |  |  | GLOBAL bool ng_ipaddr_tostr_r(const ng_ipaddr_t *addr, char *str)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_af | ng_ipaddr_af | 49 | 59 |  |  |  | static inline int ng_ipaddr_af(const ng_ipaddr_t *a)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_salen | ng_ipaddr_salen | 62 | 73 |  |  |  | static inline socklen_t ng_ipaddr_salen(const ng_ipaddr_t *a)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_getport | ng_ipaddr_getport | 76 | 92 |  |  |  | static inline UINT16 ng_ipaddr_getport(const ng_ipaddr_t *a)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_tostr | ng_ipaddr_tostr | 116 | 121 |  |  |  | static inline const char* ng_ipaddr_tostr(const ng_ipaddr_t *addr)
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.h | function | ng_ipaddr_tostr_r | ng_ipaddr_tostr_r | 123 | 130 |  |  |  | static inline bool ng_ipaddr_tostr_r(const ng_ipaddr_t *addr, char *d)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Join | Channel_Join | 250 | 283 |  |  |  | GLOBAL bool Channel_Join( CLIENT *Client, const char *Name )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Kick | Channel_Kick | 331 | 420 |  |  |  | GLOBAL void Channel_Kick(CLIENT *Peer, CLIENT *Target, CLIENT *Origin, const char *Name, const char *Reason )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Quit | Channel_Quit | 423 | 443 |  |  |  | GLOBAL void Channel_Quit( CLIENT *Client, const char *Reason )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_NextChannelOf | Channel_NextChannelOf | 617 | 623 |  |  |  | GLOBAL CL2CHAN * Channel_NextChannelOf( CLIENT *Client, CL2CHAN *Cl2Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_GetClient | Channel_GetClient | 626 | 631 |  |  |  | GLOBAL CLIENT * Channel_GetClient( CL2CHAN *Cl2Chan )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_UserModeAdd | Channel_UserModeAdd | 707 | 732 |  |  |  | GLOBAL bool Channel_UserModeAdd( CHANNEL *Chan, CLIENT *Client, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Can_Send_To_Channel | Can_Send_To_Channel | 922 | 970 |  |  |  | static bool Can_Send_To_Channel(CHANNEL *Chan, CLIENT *From)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Write | Channel_Write | 973 | 994 |  |  |  | GLOBAL bool Channel_Write(CHANNEL *Chan, CLIENT *From, CLIENT *Client, const char *Command, bool SendErrors, const char *Text)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Remove_Client | Remove_Client | 1071 | 1158 |  |  |  | static bool Remove_Client( int Type, CHANNEL *Chan, CLIENT *Client, CLIENT *Origin, const char *Reason, bool InformServer )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_AddExcept | Channel_AddExcept | 1170 | 1176 |  |  |  | GLOBAL bool Channel_AddExcept(CHANNEL *c, const char *mask, const char *who )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | ShowChannelList | ShowChannelList | 1188 | 1210 |  |  |  | static bool ShowChannelList(struct list_head *head, CLIENT *Client, CHANNEL *Channel, char *msg, char *msg_end)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_CapAdd | Client_CapAdd | 47 | 56 |  |  |  | GLOBAL void Client_CapAdd(CLIENT *Client, int Cap)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client-cap.c | function | Client_CapDel | Client_CapDel | 58 | 67 |  |  |  | GLOBAL void Client_CapDel(CLIENT *Client, int Cap)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ThisServer | Client_ThisServer | 129 | 133 |  |  |  | GLOBAL CLIENT * Client_ThisServer( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NewLocal | Client_NewLocal | 140 | 145 |  |  |  | GLOBAL CLIENT * Client_NewLocal(CONN_ID Idx, const char *Hostname, int Type, bool Idented)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NewRemoteServer | Client_NewRemoteServer | 152 | 158 |  |  |  | GLOBAL CLIENT * Client_NewRemoteServer(CLIENT *Introducer, const char *Hostname, CLIENT *TopServer, int Hops, int Token, const char *Info, bool Idented)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NewRemoteUser | Client_NewRemoteUser | 165 | 171 |  |  |  | GLOBAL CLIENT * Client_NewRemoteUser(CLIENT *Introducer, const char *Nick, int Hops, const char *User, const char *Hostname, int Token, const char *Modes, const char *Info, bool Idented)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Destroy | Client_Destroy | 227 | 322 |  |  |  | GLOBAL void Client_Destroy( CLIENT *Client, const char *LogMsg, const char *FwdMsg, bool SendQuit )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetHostname | Client_SetHostname | 334 | 359 |  |  |  | GLOBAL void Client_SetHostname( CLIENT *Client, const char *Hostname )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetIPAText | Client_SetIPAText | 368 | 380 |  |  |  | GLOBAL void Client_SetIPAText(CLIENT *Client, const char *IPAText)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetID | Client_SetID | 383 | 398 |  |  |  | GLOBAL void Client_SetID( CLIENT *Client, const char *ID )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetUser | Client_SetUser | 401 | 417 |  |  |  | GLOBAL void Client_SetUser( CLIENT *Client, const char *User, bool Idented )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetInfo | Client_SetInfo | 440 | 452 |  |  |  | GLOBAL void Client_SetInfo( CLIENT *Client, const char *Info )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetModes | Client_SetModes | 455 | 462 |  |  |  | GLOBAL void Client_SetModes( CLIENT *Client, const char *Modes )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetFlags | Client_SetFlags | 465 | 472 |  |  |  | GLOBAL void Client_SetFlags( CLIENT *Client, const char *Flags )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetAway | Client_SetAway | 491 | 506 |  |  |  | GLOBAL void Client_SetAway( CLIENT *Client, const char *Txt )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetType | Client_SetType | 509 | 516 |  |  |  | GLOBAL void Client_SetType( CLIENT *Client, int Type )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetHops | Client_SetHops | 519 | 524 |  |  |  | GLOBAL void Client_SetHops( CLIENT *Client, int Hops )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetToken | Client_SetToken | 527 | 532 |  |  |  | GLOBAL void Client_SetToken( CLIENT *Client, int Token )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SetIntroducer | Client_SetIntroducer | 535 | 541 |  |  |  | GLOBAL void Client_SetIntroducer( CLIENT *Client, CLIENT *Introducer )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ModeAdd | Client_ModeAdd | 544 | 562 |  |  |  | GLOBAL bool Client_ModeAdd( CLIENT *Client, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ModeDel | Client_ModeDel | 565 | 589 |  |  |  | GLOBAL bool Client_ModeDel( CLIENT *Client, char Mode )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Search | Client_Search | 597 | 620 |  |  |  | GLOBAL CLIENT * Client_Search( const char *Nick )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_SearchServer | Client_SearchServer | 631 | 652 |  |  |  | GLOBAL CLIENT * Client_SearchServer(const char *Mask)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_GetFromToken | Client_GetFromToken | 659 | 677 |  |  |  | GLOBAL CLIENT * Client_GetFromToken( CLIENT *Client, int Token )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Conn | Client_Conn | 688 | 693 |  |  |  | GLOBAL CONN_ID Client_Conn( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_User | Client_User | 717 | 722 |  |  |  | GLOBAL char * Client_User( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Hostname | Client_Hostname | 746 | 751 |  |  |  | GLOBAL char * Client_Hostname(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HostnameCloaked | Client_HostnameCloaked | 758 | 763 |  |  |  | GLOBAL char * Client_HostnameCloaked(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_IPAText | Client_IPAText | 790 | 803 |  |  |  | GLOBAL const char * Client_IPAText(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Hops | Client_Hops | 870 | 875 |  |  |  | GLOBAL int Client_Hops( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Token | Client_Token | 878 | 883 |  |  |  | GLOBAL int Client_Token( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyToken | Client_MyToken | 886 | 891 |  |  |  | GLOBAL int Client_MyToken( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_NextHop | Client_NextHop | 894 | 906 |  |  |  | GLOBAL CLIENT * Client_NextHop( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Mask | Client_Mask | 917 | 931 |  |  |  | GLOBAL char * Client_Mask( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MaskCloaked | Client_MaskCloaked | 945 | 960 |  |  |  | GLOBAL char * Client_MaskCloaked(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Introducer | Client_Introducer | 963 | 968 |  |  |  | GLOBAL CLIENT * Client_Introducer( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_TopServer | Client_TopServer | 971 | 976 |  |  |  | GLOBAL CLIENT * Client_TopServer( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Away | Client_Away | 995 | 1000 |  |  |  | GLOBAL char * Client_Away( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_CheckID | Client_CheckID | 1059 | 1092 |  |  |  | GLOBAL bool Client_CheckID( CLIENT *Client, char *ID )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_First | Client_First | 1095 | 1099 |  |  |  | GLOBAL CLIENT * Client_First( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Next | Client_Next | 1102 | 1107 |  |  |  | GLOBAL CLIENT * Client_Next( CLIENT *c )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_GetWhowas | Client_GetWhowas | 1244 | 1248 |  |  |  | GLOBAL WHOWAS * Client_GetWhowas( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Reject | Client_Reject | 1286 | 1303 |  |  |  | GLOBAL void Client_Reject(CLIENT *Client, const char *Reason, bool InformClient)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_RegisterWhowas | Client_RegisterWhowas | 1480 | 1515 |  |  |  | GLOBAL void Client_RegisterWhowas( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | cb_introduceClient | cb_introduceClient | 1595 | 1602 |  |  |  | static void cb_introduceClient(CLIENT *To, CLIENT *Prefix, void *data)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Announce | Client_Announce | 1615 | 1692 |  |  |  | GLOBAL bool Client_Announce(CLIENT * Client, CLIENT * Prefix, CLIENT * User)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_SetEncoding | Conn_SetEncoding | 45 | 76 |  |  |  | GLOBAL bool Conn_SetEncoding(CONN_ID Conn, const char *ClientEnc)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_UnsetEncoding | Conn_UnsetEncoding | 83 | 97 |  |  |  | GLOBAL void Conn_UnsetEncoding(CONN_ID Conn)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Convert_Message | Convert_Message | 109 | 130 |  |  |  | char * Convert_Message(iconv_t Handle, char *Message)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_EncodingFrom | Conn_EncodingFrom | 148 | 159 |  |  |  | GLOBAL char * Conn_EncodingFrom(UNUSED CONN_ID Conn, char *Message)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-encoding.c | function | Conn_EncodingTo | Conn_EncodingTo | 175 | 186 |  |  |  | GLOBAL char * Conn_EncodingTo(UNUSED CONN_ID Conn, char *Message)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_UpdateIdle | Conn_UpdateIdle | 35 | 40 |  |  |  | GLOBAL void Conn_UpdateIdle(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_UpdatePing | Conn_UpdatePing | 51 | 56 |  |  |  | GLOBAL void Conn_UpdatePing(CONN_ID Idx, time_t TimeStamp)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_GetSignon | Conn_GetSignon | 61 | 66 |  |  |  | GLOBAL time_t Conn_GetSignon(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_GetIdle | Conn_GetIdle | 68 | 74 |  |  |  | GLOBAL time_t Conn_GetIdle( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_LastPing | Conn_LastPing | 76 | 81 |  |  |  | GLOBAL time_t Conn_LastPing( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SetPenalty | Conn_SetPenalty | 94 | 120 |  |  |  | GLOBAL void Conn_SetPenalty(CONN_ID Idx, time_t Seconds)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_ClearFlags | Conn_ClearFlags | 122 | 128 |  |  |  | GLOBAL void Conn_ClearFlags( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_Flag | Conn_Flag | 130 | 135 |  |  |  | GLOBAL int Conn_Flag( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SetFlag | Conn_SetFlag | 137 | 142 |  |  |  | GLOBAL void Conn_SetFlag( CONN_ID Idx, int Flag )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_First | Conn_First | 144 | 154 |  |  |  | GLOBAL CONN_ID Conn_First( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_Next | Conn_Next | 156 | 168 |  |  |  | GLOBAL CONN_ID Conn_Next( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_Options | Conn_Options | 170 | 175 |  |  |  | GLOBAL UINT16 Conn_Options( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SetOption | Conn_SetOption | 180 | 185 |  |  |  | GLOBAL void Conn_SetOption(CONN_ID Idx, int Option)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_StartTime | Conn_StartTime | 192 | 205 |  |  |  | GLOBAL time_t Conn_StartTime( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SendQ | Conn_SendQ | 210 | 220 |  |  |  | GLOBAL size_t Conn_SendQ( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SendMsg | Conn_SendMsg | 225 | 231 |  |  |  | GLOBAL long Conn_SendMsg( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_SendBytes | Conn_SendBytes | 237 | 242 |  |  |  | GLOBAL long Conn_SendBytes( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_RecvQ | Conn_RecvQ | 247 | 257 |  |  |  | GLOBAL size_t Conn_RecvQ( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_RecvMsg | Conn_RecvMsg | 262 | 267 |  |  |  | GLOBAL long Conn_RecvMsg( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_RecvBytes | Conn_RecvBytes | 273 | 278 |  |  |  | GLOBAL long Conn_RecvBytes( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_IPA | Conn_IPA | 283 | 288 |  |  |  | GLOBAL const char * Conn_IPA(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_ResetWCounter | Conn_ResetWCounter | 290 | 294 |  |  |  | GLOBAL void Conn_ResetWCounter( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-func.c | function | Conn_WCounter | Conn_WCounter | 296 | 300 |  |  |  | GLOBAL long Conn_WCounter( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | openreadclose | openreadclose | 91 | 131 |  |  |  | static char * openreadclose(const char *name, size_t *len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | Verify_openssl | Verify_openssl | 211 | 231 |  |  |  | static int Verify_openssl(int preverify_ok, X509_STORE_CTX * ctx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Free | ConnSSL_Free | 306 | 345 |  |  |  | void ConnSSL_Free(CONNECTION *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_InitLibrary | ConnSSL_InitLibrary | 348 | 459 |  |  |  | bool ConnSSL_InitLibrary( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_SetVerifyProperties_gnutls | ConnSSL_SetVerifyProperties_gnutls | 463 | 494 |  |  |  | static bool ConnSSL_SetVerifyProperties_gnutls(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_LoadServerKey_gnutls | ConnSSL_LoadServerKey_gnutls | 497 | 577 |  |  |  | static bool ConnSSL_LoadServerKey_gnutls(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_LoadServerKey_openssl | ConnSSL_LoadServerKey_openssl | 582 | 621 |  |  |  | static bool ConnSSL_LoadServerKey_openssl(SSL_CTX *ctx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_SetVerifyProperties_openssl | ConnSSL_SetVerifyProperties_openssl | 624 | 671 |  |  |  | static bool ConnSSL_SetVerifyProperties_openssl(SSL_CTX * ctx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Init_SSL | ConnSSL_Init_SSL | 675 | 741 |  |  |  | static bool ConnSSL_Init_SSL(CONNECTION *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_PrepareConnect | ConnSSL_PrepareConnect | 744 | 785 |  |  |  | bool ConnSSL_PrepareConnect(CONNECTION * c, CONF_SERVER * s)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_HandleError | ConnSSL_HandleError | 803 | 883 |  |  |  | static int ConnSSL_HandleError(CONNECTION * c, const int code, const char *fname)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_LogCertInfo | ConnSSL_LogCertInfo | 938 | 1082 |  |  |  | static void ConnSSL_LogCertInfo( CONNECTION * c, bool connect)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Accept | ConnSSL_Accept | 1092 | 1109 |  |  |  | int ConnSSL_Accept( CONNECTION *c )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Connect | ConnSSL_Connect | 1112 | 1121 |  |  |  | int ConnSSL_Connect( CONNECTION *c )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_InitCertFp | ConnSSL_InitCertFp | 1123 | 1196 |  |  |  | static int ConnSSL_InitCertFp( CONNECTION *c )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnectAccept | ConnectAccept | 1199 | 1224 |  |  |  | static int ConnectAccept( CONNECTION *c, bool connect)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Write | ConnSSL_Write | 1227 | 1246 |  |  |  | ssize_t ConnSSL_Write(CONNECTION *c, const void *buf, size_t count)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_Read | ConnSSL_Read | 1249 | 1271 |  |  |  | ssize_t ConnSSL_Read(CONNECTION *c, void * buf, size_t count)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_GetCipherInfo | ConnSSL_GetCipherInfo | 1274 | 1308 |  |  |  | bool ConnSSL_GetCipherInfo(CONNECTION *c, char *buf, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_GetCertFp | ConnSSL_GetCertFp | 1310 | 1314 |  |  |  | char * ConnSSL_GetCertFp(CONNECTION *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_SetCertFp | ConnSSL_SetCertFp | 1316 | 1322 |  |  |  | bool ConnSSL_SetCertFp(CONNECTION *c, const char *fingerprint)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | ConnSSL_InitLibrary | ConnSSL_InitLibrary | 1325 | 1329 |  |  |  | bool ConnSSL_InitLibrary(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_InitConn | Zip_InitConn | 38 | 75 |  |  |  | GLOBAL bool Zip_InitConn( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_Buffer | Zip_Buffer | 90 | 114 |  |  |  | GLOBAL bool Zip_Buffer( CONN_ID Idx, const char *Data, size_t Len )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_Flush | Zip_Flush | 124 | 182 |  |  |  | GLOBAL bool Zip_Flush( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Unzip_Buffer | Unzip_Buffer | 193 | 253 |  |  |  | GLOBAL bool Unzip_Buffer( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_SendBytes | Zip_SendBytes | 260 | 265 |  |  |  | GLOBAL long Zip_SendBytes( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-zip.c | function | Zip_RecvBytes | Zip_RecvBytes | 272 | 277 |  |  |  | GLOBAL long Zip_RecvBytes( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_listen | cb_listen | 166 | 171 |  |  |  | static void cb_listen(int sock, short irrelevant)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_connserver | cb_connserver | 179 | 248 |  |  |  | static void cb_connserver(int sock, UNUSED short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | server_login | server_login | 255 | 271 |  |  |  | static void server_login(CONN_ID idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_clientserver | cb_clientserver | 279 | 302 |  |  |  | static void cb_clientserver(int sock, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Init | Conn_Init | 307 | 324 |  |  |  | GLOBAL void Conn_Init( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Exit | Conn_Exit | 329 | 348 |  |  |  | GLOBAL void Conn_Exit( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_CloseAllSockets | Conn_CloseAllSockets | 355 | 365 |  |  |  | GLOBAL void Conn_CloseAllSockets(int ExceptOf)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Init_Listeners | Init_Listeners | 375 | 403 |  |  |  | static unsigned int Init_Listeners(array *a, const char *listen_addr, void (*func)(int,short))
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_InitListeners | Conn_InitListeners | 410 | 522 |  |  |  | GLOBAL unsigned int Conn_InitListeners( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 434 | 434 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | InitSinaddrListenAddr | InitSinaddrListenAddr | 561 | 574 |  |  |  | static bool InitSinaddrListenAddr(ng_ipaddr_t *addr, const char *listen_addrstr, UINT16 Port)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | set_v6_only | set_v6_only | 584 | 599 |  |  |  | static void set_v6_only(int af, int sock)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | NewListener | NewListener | 608 | 655 |  |  |  | static int NewListener(const char *listen_addr, UINT16 Port)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 631 | 631 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Handler | Conn_Handler | 666 | 815 |  |  |  | GLOBAL void Conn_Handler(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Password | Conn_Password | 915 | 923 |  |  |  | GLOBAL char* Conn_Password( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetPassword | Conn_SetPassword | 925 | 938 |  |  |  | GLOBAL void Conn_SetPassword( CONN_ID Idx, const char *Pwd )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Write | Conn_Write | 948 | 1021 |  |  |  | static bool Conn_Write( CONN_ID Idx, char *Data, size_t Len )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Close | Conn_Close | 1034 | 1181 |  |  |  | GLOBAL void Conn_Close(CONN_ID Idx, const char *LogMsg, const char *FwdMsg, bool InformClient)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_Count | Conn_Count | 1188 | 1192 |  |  |  | GLOBAL long Conn_Count(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_CountAccepted | Conn_CountAccepted | 1210 | 1214 |  |  |  | GLOBAL long Conn_CountAccepted(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetIPAInfo | Conn_GetIPAInfo | 1253 | 1258 |  |  |  | GLOBAL const char * Conn_GetIPAInfo(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Handle_Write | Handle_Write | 1266 | 1336 |  |  |  | static bool Handle_Write( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Count_Connections | Count_Connections | 1343 | 1356 |  |  |  | static int Count_Connections(ng_ipaddr_t *a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | New_Connection | New_Connection | 1365 | 1491 |  |  |  | static int New_Connection(int Sock, UNUSED bool IsSSL)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 1382 | 1382 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_StartLogin | Conn_StartLogin | 1498 | 1539 |  |  |  | GLOBAL void Conn_StartLogin(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Account_Connection | Account_Connection | 1544 | 1553 |  |  |  | static void Account_Connection(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Socket2Index | Socket2Index | 1562 | 1587 |  |  |  | static CONN_ID Socket2Index( int Sock )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Read_Request | Read_Request | 1595 | 1710 |  |  |  | static void Read_Request(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Handle_Buffer | Handle_Buffer | 1722 | 1889 |  |  |  | static unsigned int Handle_Buffer(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Check_Connections | Check_Connections | 1896 | 1950 |  |  |  | static void Check_Connections(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Check_Servers | Check_Servers | 1955 | 2000 |  |  |  | static void Check_Servers(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | New_Server | New_Server | 2008 | 2129 |  |  |  | static void New_Server( int Server , ng_ipaddr_t *dest)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 2057 | 2057 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | sockaddr | sockaddr | 2065 | 2065 |  |  |  | struct sockaddr
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Init_Socket | Init_Socket | 2163 | 2198 |  |  |  | static bool Init_Socket( int Sock )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_Connect_to_Server | cb_Connect_to_Server | 2207 | 2261 |  |  |  | static void cb_Connect_to_Server(int fd, UNUSED short events)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_Read_Resolver_Result | cb_Read_Resolver_Result | 2270 | 2382 |  |  |  | static void cb_Read_Resolver_Result( int r_fd, UNUSED short events )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Simple_Message | Simple_Message | 2394 | 2415 |  |  |  | static void Simple_Message(int Sock, const char *Msg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetClient | Conn_GetClient | 2425 | 2434 |  |  |  | GLOBAL CLIENT * Conn_GetClient( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetProcStat | Conn_GetProcStat | 2442 | 2451 |  |  |  | GLOBAL PROC_STAT * Conn_GetProcStat(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetFromProc | Conn_GetFromProc | 2459 | 2471 |  |  |  | GLOBAL CONN_ID Conn_GetFromProc(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Throttle_Connection | Throttle_Connection | 2481 | 2501 |  |  |  | static void Throttle_Connection(const CONN_ID Idx, CLIENT *Client, const int Reason, unsigned int Value)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetAuthPing | Conn_GetAuthPing | 2505 | 2510 |  |  |  | GLOBAL long Conn_GetAuthPing(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetAuthPing | Conn_SetAuthPing | 2512 | 2517 |  |  |  | GLOBAL void Conn_SetAuthPing(CONN_ID Idx, long ID)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_clientserver_ssl | cb_clientserver_ssl | 2529 | 2552 |  |  |  | static void cb_clientserver_ssl(int sock, UNUSED short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_listen_ssl | cb_listen_ssl | 2561 | 2571 |  |  |  | static void cb_listen_ssl(int sock, short irrelevant)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | cb_connserver_login_ssl | cb_connserver_login_ssl | 2586 | 2630 |  |  |  | static void cb_connserver_login_ssl(int sock, short unused)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | SSL_WantRead | SSL_WantRead | 2650 | 2658 |  |  |  | static bool SSL_WantRead(const CONNECTION *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | SSL_WantWrite | SSL_WantWrite | 2668 | 2676 |  |  |  | static bool SSL_WantWrite(const CONNECTION *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetCipherInfo | Conn_GetCipherInfo | 2686 | 2693 |  |  |  | GLOBAL bool Conn_GetCipherInfo(CONN_ID Idx, char *buf, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_UsesSSL | Conn_UsesSSL | 2701 | 2708 |  |  |  | GLOBAL bool Conn_UsesSSL(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_UsesSSL | Conn_UsesSSL | 2730 | 2734 |  |  |  | GLOBAL bool Conn_UsesSSL(UNUSED CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_get | io_event_get | 159 | 171 |  |  |  | static io_event * io_event_get(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_devpoll | io_dispatch_devpoll | 175 | 208 |  |  |  | static int io_dispatch_devpoll(struct timeval *tv)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_devpoll | io_event_change_devpoll | 211 | 225 |  |  |  | static bool io_event_change_devpoll(int fd, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | pollfd | pollfd | 214 | 214 |  |  |  | struct pollfd
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_poll | io_dispatch_poll | 256 | 294 |  |  |  | static int io_dispatch_poll(struct timeval *tv)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_poll | io_event_change_poll | 296 | 315 |  |  |  | static bool io_event_change_poll(int fd, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_poll | io_close_poll | 317 | 333 |  |  |  | static void io_close_poll(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_select | io_dispatch_select | 364 | 400 |  |  |  | static int io_dispatch_select(struct timeval *tv)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_select | io_close_select | 426 | 447 |  |  |  | static void io_close_select(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_epoll | io_event_change_epoll | 459 | 471 |  |  |  | static bool io_event_change_epoll(int fd, short what, const int action)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | epoll_event | epoll_event | 462 | 462 |  |  |  | struct epoll_event
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_epoll | io_dispatch_epoll | 473 | 501 |  |  |  | static int io_dispatch_epoll(struct timeval *tv)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | struct | epoll_event | epoll_event | 478 | 478 |  |  |  | struct epoll_event
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_change_kqueue | io_event_change_kqueue | 556 | 579 |  |  |  | static bool io_event_change_kqueue(int fd, short what, const int action)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch_kqueue | io_dispatch_kqueue | 581 | 628 |  |  |  | static int io_dispatch_kqueue(struct timeval *tv)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_setcb | io_event_setcb | 686 | 695 |  |  |  | bool io_event_setcb(int fd, void (*cbfunc) (int, short))
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | backend_create_ev | backend_create_ev | 698 | 719 |  |  |  | static bool backend_create_ev(int fd, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_create | io_event_create | 722 | 751 |  |  |  | bool io_event_create(int fd, short what, void (*cbfunc) (int, short))
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_add | io_event_add | 754 | 792 |  |  |  | bool io_event_add(int fd, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close | io_close | 822 | 851 |  |  |  | bool io_close(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_del | io_event_del | 854 | 888 |  |  |  | bool io_event_del(int fd, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_dispatch | io_dispatch | 891 | 911 |  |  |  | int io_dispatch(struct timeval *tv)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_docallback | io_docallback | 915 | 927 |  |  |  | static void io_docallback(int fd, short what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_LS | Handle_CAP_LS | 118 | 128 |  |  |  | static bool Handle_CAP_LS(CLIENT *Client, UNUSED char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_LIST | Handle_CAP_LIST | 137 | 144 |  |  |  | static bool Handle_CAP_LIST(CLIENT *Client, UNUSED char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_REQ | Handle_CAP_REQ | 153 | 172 |  |  |  | static bool Handle_CAP_REQ(CLIENT *Client, char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_ACK | Handle_CAP_ACK | 181 | 188 |  |  |  | static bool Handle_CAP_ACK(UNUSED CLIENT *Client, UNUSED char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_CLEAR | Handle_CAP_CLEAR | 196 | 209 |  |  |  | static bool Handle_CAP_CLEAR(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Handle_CAP_END | Handle_CAP_END | 217 | 233 |  |  |  | static bool Handle_CAP_END(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | IRC_CAP | IRC_CAP | 244 | 274 |  |  |  | GLOBAL bool IRC_CAP(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | part_from_all_channels | part_from_all_channels | 53 | 65 |  |  |  | static bool part_from_all_channels(CLIENT* client, CLIENT *target)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | cb_join_forward | cb_join_forward | 183 | 204 |  |  |  | static void cb_join_forward(CLIENT *To, CLIENT *Prefix, void *Data)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | join_forward | join_forward | 217 | 248 |  |  |  | static void join_forward(CLIENT *Client, CLIENT *target, CHANNEL *chan, const char *channame)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_Send_Channel_Info | IRC_Send_Channel_Info | 256 | 282 |  |  |  | GLOBAL bool IRC_Send_Channel_Info(CLIENT *Client, CHANNEL *Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_JOIN | IRC_JOIN | 291 | 428 |  |  |  | GLOBAL bool IRC_JOIN( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_PART | IRC_PART | 437 | 467 |  |  |  | GLOBAL bool IRC_PART(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-channel.c | function | IRC_LIST | IRC_LIST | 578 | 655 |  |  |  | GLOBAL bool IRC_LIST( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-encoding.c | function | IRC_CHARCONV | IRC_CHARCONV | 41 | 58 |  |  |  | GLOBAL bool IRC_CHARCONV(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHOIS_SendReply | IRC_WHOIS_SendReply | 294 | 438 |  |  |  | static bool IRC_WHOIS_SendReply(CLIENT *Client, CLIENT *from, CLIENT *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_ISON | IRC_ISON | 594 | 623 |  |  |  | GLOBAL bool IRC_ISON( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_LINKS | IRC_LINKS | 632 | 676 |  |  |  | GLOBAL bool IRC_LINKS(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_SERVLIST | IRC_SERVLIST | 714 | 740 |  |  |  | GLOBAL bool IRC_SERVLIST(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_SUMMON | IRC_SUMMON | 985 | 992 |  |  |  | GLOBAL bool IRC_SUMMON(CLIENT * Client, UNUSED REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHO | IRC_WHO | 1137 | 1176 |  |  |  | GLOBAL bool IRC_WHO(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHOIS | IRC_WHOIS | 1185 | 1285 |  |  |  | GLOBAL bool IRC_WHOIS( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_WHOWAS | IRC_WHOWAS | 1294 | 1373 |  |  |  | GLOBAL bool IRC_WHOWAS( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Send_LUSERS | IRC_Send_LUSERS | 1381 | 1445 |  |  |  | GLOBAL bool IRC_Send_LUSERS(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Send_NAMES | IRC_Send_NAMES | 1496 | 1561 |  |  |  | GLOBAL bool IRC_Send_NAMES(CLIENT * Client, CHANNEL * Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Send_ISUPPORT | IRC_Send_ISUPPORT | 1568 | 1583 |  |  |  | GLOBAL bool IRC_Send_ISUPPORT(CLIENT * Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_SVSNICK | IRC_SVSNICK | 375 | 411 |  |  |  | GLOBAL bool IRC_SVSNICK(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_WEBIRC | IRC_WEBIRC | 618 | 637 |  |  |  | GLOBAL bool IRC_WEBIRC(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_QUIT | IRC_QUIT | 646 | 693 |  |  |  | GLOBAL bool IRC_QUIT( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_QUIT_HTTP | IRC_QUIT_HTTP | 707 | 713 |  |  |  | GLOBAL bool IRC_QUIT_HTTP( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_PING | IRC_PING | 724 | 789 |  |  |  | GLOBAL bool IRC_PING(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_PONG | IRC_PONG | 798 | 892 |  |  |  | GLOBAL bool IRC_PONG(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Send_ListChange | Send_ListChange | 1128 | 1152 |  |  |  | static bool Send_ListChange(const bool IsAdd, const char ModeChar, CLIENT *Prefix, CLIENT *Client, CHANNEL *Channel, const char *Mask)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-op.c | function | try_kick | try_kick | 35 | 47 |  |  |  | static bool try_kick(CLIENT *peer, CLIENT* from, const char *nick, const char *channel, const char *reason)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-op.c | function | IRC_KICK | IRC_KICK | 58 | 125 |  |  |  | GLOBAL bool IRC_KICK(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-op.c | function | IRC_INVITE | IRC_INVITE | 134 | 236 |  |  |  | GLOBAL bool IRC_INVITE(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_REHASH | IRC_REHASH | 150 | 168 |  |  |  | GLOBAL bool IRC_REHASH( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_CONNECT | IRC_CONNECT | 202 | 294 |  |  |  | GLOBAL bool IRC_CONNECT(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_DISCONNECT | IRC_DISCONNECT | 306 | 338 |  |  |  | GLOBAL bool IRC_DISCONNECT(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_WALLOPS | IRC_WALLOPS | 347 | 375 |  |  |  | GLOBAL bool IRC_WALLOPS( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_xLINE | IRC_xLINE | 384 | 480 |  |  |  | GLOBAL bool IRC_xLINE(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-server.c | function | IRC_SERVER | IRC_SERVER | 49 | 255 |  |  |  | GLOBAL bool IRC_SERVER( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-server.c | function | IRC_NJOIN | IRC_NJOIN | 264 | 376 |  |  |  | GLOBAL bool IRC_NJOIN( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-server.c | function | IRC_SQUIT | IRC_SQUIT | 385 | 475 |  |  |  | GLOBAL bool IRC_SQUIT(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | IRC_WriteStrServersPrefixFlag_CB | IRC_WriteStrServersPrefixFlag_CB | 388 | 404 |  |  |  | GLOBAL void IRC_WriteStrServersPrefixFlag_CB(CLIENT *ExceptOf, CLIENT *Prefix, char Flag, void (*callback)(CLIENT *, CLIENT *, void *), void *cb_data)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | cb_writeStrServersPrefixFlag | cb_writeStrServersPrefixFlag | 571 | 575 |  |  |  | static void cb_writeStrServersPrefixFlag(CLIENT *Client, CLIENT *Prefix, void *Buffer)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-write.c | function | Send_Marked_Connections | Send_Marked_Connections | 583 | 601 |  |  |  | static void Send_Marked_Connections(CLIENT *Prefix, const char *Buffer)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_KILL | IRC_KILL | 138 | 179 |  |  |  | GLOBAL bool IRC_KILL(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_NOTICE | IRC_NOTICE | 188 | 192 |  |  |  | GLOBAL bool IRC_NOTICE(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_PRIVMSG | IRC_PRIVMSG | 201 | 205 |  |  |  | GLOBAL bool IRC_PRIVMSG(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_SQUERY | IRC_SQUERY | 214 | 218 |  |  |  | GLOBAL bool IRC_SQUERY(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_HELP | IRC_HELP | 304 | 331 |  |  |  | GLOBAL bool IRC_HELP(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_KillClient | IRC_KillClient | 348 | 412 |  |  |  | GLOBAL bool IRC_KillClient(CLIENT *Client, CLIENT *From, const char *Nick, const char *Reason)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | Send_Message_Mask | Send_Message_Mask | 791 | 847 |  |  |  | static bool Send_Message_Mask(CLIENT * from, char * command, char * targetMask, char * message, bool SendErrors)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | Login_Autojoin | Login_Autojoin | 219 | 240 |  |  |  | GLOBAL void Login_Autojoin(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | Match | Match | 50 | 57 |  |  |  | GLOBAL bool Match( const char *Pattern, const char *String )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | Matche | Matche | 103 | 131 |  |  |  | static int Matche( const char *p, const char *t )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | Matche_After_Star | Matche_After_Star | 133 | 180 |  |  |  | static int Matche_After_Star( const char *p, const char *t )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Announce_Channel | Announce_Channel | 39 | 112 |  |  |  | static bool Announce_Channel(CLIENT *Client, CHANNEL *Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Announce_Server | Announce_Server | 119 | 143 |  |  |  | static bool Announce_Server(CLIENT * Client, CLIENT * Server)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Send_List | Send_List | 150 | 165 |  |  |  | static bool Send_List(CLIENT *Client, CHANNEL *Chan, struct list_head *Head, char Type)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Synchronize_Lists | Synchronize_Lists | 173 | 207 |  |  |  | static bool Synchronize_Lists(CLIENT * Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\numeric.c | function | Send_CHANINFO | Send_CHANINFO | 214 | 249 |  |  |  | static bool Send_CHANINFO(CLIENT * Client, CHANNEL * Chan)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\op.c | function | Op_Check | Op_Check | 66 | 92 |  |  |  | GLOBAL CLIENT * Op_Check(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Parse_Request | Parse_Request | 175 | 268 |  |  |  | GLOBAL bool Parse_Request( CONN_ID Idx, char *Request )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | ScrubCTCP | ScrubCTCP | 582 | 609 |  |  |  | static bool ScrubCTCP(char *Request)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Resolve_Addr_Ident | Resolve_Addr_Ident | 57 | 79 |  |  |  | GLOBAL bool Resolve_Addr_Ident(PROC_STAT * s, const ng_ipaddr_t *Addr, int identsock, void (*cbfunc) (int, short))
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Resolve_Name | Resolve_Name | 85 | 107 |  |  |  | GLOBAL bool Resolve_Name( PROC_STAT *s, const char *Host, void (*cbfunc)(int, short))
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Do_IdentQuery | Do_IdentQuery | 132 | 158 |  |  |  | static void Do_IdentQuery(int identsock, array *resolved_addr)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | ReverseLookup | ReverseLookup | 170 | 217 |  |  |  | static bool ReverseLookup(const ng_ipaddr_t *IpAddr, char *resbuf, size_t reslen)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Addr_in_list | Addr_in_list | 295 | 324 |  |  |  | static bool Addr_in_list(const array *resolved_addr, const ng_ipaddr_t *Addr)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Do_ResolveAddr_Ident | Do_ResolveAddr_Ident | 358 | 407 |  |  |  | static void Do_ResolveAddr_Ident(const ng_ipaddr_t *Addr, int identsock, int w_fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Do_ResolveName | Do_ResolveName | 410 | 450 |  |  |  | static void Do_ResolveName( const char *Host, int w_fd )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sockaddr | sockaddr | 430 | 430 |  |  |  | struct sockaddr
```

## Component: Infrastructure / Platform
- Category: technical
- Assigned symbols: 95

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_init | ng_ipaddr_init | 23 | 77 | Initializes the IP address structure and validates the input string and port parameters. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Init | Channel_Init | 59 | 64 | Initializes the channel state and registers it with the server's channel management system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_InitPredefined | Channel_InitPredefined | 94 | 202 | Initializes predefined channel structures within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Exit | Channel_Exit | 218 | 239 | A core server function responsible for cleaning up and exiting the channel state when a connection is closed. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_LogServer | Channel_LogServer | 1255 | 1269 | Implements internal logging functionality for channel messages within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_Init | Class_Init | 30 | 34 | Initializes the ngIRCd class instance and sets up its core runtime state. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_Exit | Class_Exit | 36 | 42 | A global function responsible for exiting the Class_Exit object, likely managing cleanup or resource release for the class instance. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_GetMemberReason | Class_GetMemberReason | 44 | 69 | Provides a utility function to retrieve member reasons for a class, likely used for debugging or internal class definition management. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Init | Client_Init | 71 | 103 | Initializes the client connection and sets up the basic runtime environment for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Exit | Client_Exit | 106 | 126 | Handles the cleanup and termination of the ngIRCd client process. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HostnameDisplayed | Client_HostnameDisplayed | 773 | 788 | A function that displays the hostname of the client connection, likely used for logging or debugging purposes. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ServerCount | Client_ServerCount | 1124 | 1128 | A global helper function used for managing the server's client connection count, likely involved in resource tracking or initialization logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyServerCount | Client_MyServerCount | 1145 | 1158 | A global utility function used to retrieve the count of configured servers within the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_OperCount | Client_OperCount | 1161 | 1175 | A global utility function used to track the number of client operations performed by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_UnknownCount | Client_UnknownCount | 1178 | 1192 | A global utility function used to manage the count of unknown client connections within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_StartTime | Client_StartTime | 1265 | 1270 | Global utility function for retrieving the client's start time, likely used for session initialization or logging. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Free_Client | Free_Client | 1411 | 1428 | Function responsible for freeing allocated client resources and managing memory cleanup. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Adjust_Counters | Adjust_Counters | 1454 | 1471 | Implements internal state management for client counters within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Destroy_UserOrService | Destroy_UserOrService | 1541 | 1585 | A function responsible for cleaning up resources and terminating a client connection or service. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | opers_free | opers_free | 291 | 304 | Function responsible for freeing allocated memory resources for operator data structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | field | refcnt | refcnt | 70 | 70 | Declares a scalar integer variable used for reference counting within the SSL connection module. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogMalloc | LogMalloc | 887 | 895 | A utility function for allocating memory with logging, likely used for internal data structures or temporary buffers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | my_sd_listen_fds | my_sd_listen_fds | 135 | 157 | Implements the listening file descriptor mechanism for the server socket. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_ExitListeners | Conn_ExitListeners | 527 | 551 | Handles cleanup and exit listeners for network connection objects. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_CountMax | Conn_CountMax | 1199 | 1203 | Defines a global constant for the maximum connection count limit used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SyncServerStruct | Conn_SyncServerStruct | 1220 | 1245 | A global function responsible for initializing or managing the connection synchronization state within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Init_Conn_Struct | Init_Conn_Struct | 2136 | 2152 | Initializes the connection structure for the network connection handler. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_devpoll | io_close_devpoll | 227 | 234 | Implements low-level device polling and socket cleanup logic for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_devpoll | io_library_init_devpoll | 236 | 244 | Initializes the development polling event library for the io library. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_devpoll | io_close_devpoll | 246 | 248 | A static inline helper function used to close a device poll descriptor, likely managing low-level I/O or socket resource cleanup. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_devpoll | io_library_init_devpoll | 249 | 251 | Initializes the development polling event loop for the io library. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_poll | io_library_init_poll | 335 | 352 | Initializes the polling event loop for the IO library, a core runtime component for handling I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_poll | io_close_poll | 354 | 356 | A static inline helper function used for managing the poll loop and closing network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_poll | io_library_init_poll | 357 | 359 | Initializes the polling event loop for the IO library, a core runtime component for handling I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_select | io_library_init_select | 402 | 424 | Initializes the IO library and handles event selection for the server's input/output subsystem. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_select | io_library_init_select | 449 | 451 | Initializes the IO library and handles the selection of the appropriate IO library for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_select | io_close_select | 452 | 454 | A static inline helper function for closing a select socket connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_epoll | io_library_init_epoll | 503 | 520 | Initializes the epoll event loop for network I/O handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_epoll | io_library_init_epoll | 522 | 524 | Initializes the epoll event loop for network I/O handling. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_kqueue_commit_cache | io_event_kqueue_commit_cache | 529 | 554 | Implements the kqueue event loop mechanism for managing and committing cached network events in the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_kqueue | io_library_init_kqueue | 630 | 640 | Initializes the I/O library using the Kqueue event loop for asynchronous I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_kqueue | io_library_init_kqueue | 642 | 644 | Initializes the I/O library using the Kqueue event loop for asynchronous I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init | io_library_init | 648 | 664 | Initializes the IO library and sets up the event loop for the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_shutdown | io_library_shutdown | 667 | 683 | Handles shutdown of the IO library, likely managing cleanup of network sockets and file descriptors. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_setnonblock | io_setnonblock | 795 | 807 | Implements non-blocking I/O operations for network sockets. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_setcloexec | io_setcloexec | 809 | 820 | Implements low-level file descriptor management for socket and I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Parse_CAP | Parse_CAP | 57 | 87 | Implements low-level parsing logic for server capabilities and command arguments. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | uptime_days | uptime_days | 58 | 62 | Implements a utility function to calculate the uptime duration in days for the current time. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | write_whoreply | write_whoreply | 76 | 84 | Implements the write_whoreply function to handle IRC channel data transmission and protocol formatting. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | who_flags_qualifier | who_flags_qualifier | 95 | 128 | Implements the `who_flags_qualifier` function to handle IRC client connection flags and channel user mode validation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | Show_MOTD_SSLInfo | Show_MOTD_SSLInfo | 457 | 480 | Implements a static function to retrieve SSL information regarding the MOTD (Message of the Day) for the client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | Show_MOTD_SSLInfo | Show_MOTD_SSLInfo | 482 | 486 | A static helper function used to retrieve SSL information from the MOTD (Message of the Day) string. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_ADMIN | IRC_ADMIN | 498 | 530 | Provides the core IRC administrative interface for handling client requests and internal state management. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Show_MOTD | IRC_Show_MOTD | 1447 | 1487 | Implements the IRC server's display of the Message of the Day (MOTD) to clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Del_From_List | Del_From_List | 1084 | 1115 | Implements the core logic for removing entries from a list within the IRC mode handler. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | Bad_OperPass | Bad_OperPass | 47 | 56 | A static function implementing a protocol operation handler for the IRC client connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_DIE | IRC_DIE | 110 | 141 | Core server logic handling critical server shutdown events and client disconnections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_RESTART | IRC_RESTART | 177 | 193 | Handles the server's startup sequence and initialization of core components. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_TRACE | IRC_TRACE | 227 | 295 | A utility function used for tracing IRC client requests, likely involved in performance monitoring or debugging. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | Help | Help | 421 | 477 | Helper function for displaying help information to the client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Free | Lists_Free | 230 | 247 | Function responsible for freeing allocated memory resources within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Init_Subprocess | Log_Init_Subprocess | 206 | 214 | Initializes a subprocess for logging operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | main | main | 73 | 333 | Entry point function that initializes the ngIRCd server process and sets up the command-line interface. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Fill_Version | Fill_Version | 344 | 448 | A static function used to populate version information, likely for logging or configuration metadata. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Show_Version | Show_Version | 454 | 462 | A static function used to display the version information of the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Pidfile_Delete | Pidfile_Delete | 492 | 502 | A static helper function responsible for deleting a PID file, likely managing system-level process or resource cleanup. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Pidfile_Create | Pidfile_Create | 510 | 542 | Creates a PID file for the ngIRCd process, managing file system operations and process lifecycle. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Setup_FDStreams | Setup_FDStreams | 550 | 561 | Handles the creation and management of file descriptor streams for network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Random_Init | Random_Init | 609 | 613 | Initializes the random number generator used by the server for generating unique identifiers or session tokens. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Random_Init_Kern | Random_Init_Kern | 615 | 628 | Initializes the kernel state and random number generator for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Random_Init | Random_Init | 633 | 643 | Initializes the random number generator used by the server for generating unique identifiers or session tokens. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | NGIRCd_Init | NGIRCd_Init | 654 | 836 | Initializes the NGIRCd daemon process and sets up the server's core runtime environment. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Parse_GetCommandStruct | Parse_GetCommandStruct | 150 | 154 | Provides the function declaration for parsing global command structures, which is a core runtime operation for the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Init_Request | Init_Request | 275 | 286 | Core server initialization logic responsible for parsing incoming request structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Validate_Prefix | Validate_Prefix | 289 | 363 | Implements low-level parsing logic for network connection identifiers and request structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_InitStruct | Proc_InitStruct | 37 | 43 | Defines the structure for processing server process information, likely used for internal state tracking or initialization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_Fork | Proc_Fork | 48 | 107 | Implements the system-level process management and fork operation for the IRC daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_GenericSignalHandler | Proc_GenericSignalHandler | 112 | 123 | Handles signal processing and system-level event management for the server process. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_Read | Proc_Read | 130 | 153 | Implements the low-level reading logic for the IRC process state structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_Close | Proc_Close | 158 | 166 | Handles the cleanup and termination of a server process instance. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Dump_State | Dump_State | 50 | 64 | A static function used for internal state dumping, likely part of the server's runtime initialization or debugging infrastructure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Block | Signal_Block | 67 | 80 | Handles signal handling and system-level event management for the application. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Unblock | Signal_Unblock | 82 | 96 | Handles signal management and interrupt handling for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Handler | Signal_Handler | 161 | 215 | Handles signal reception and routing for the ngIRCd server process lifecycle. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Handler_BH | Signal_Handler_BH | 226 | 245 | Handles signal reception and processing for the server's initialization or runtime events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Callback | Signal_Callback | 247 | 270 | Handles signal delivery and callback registration for the server's event loop. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signals_Init | Signals_Init | 277 | 319 | Initializes the signal handling mechanism for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sigaction | sigaction | 282 | 282 | Implements the sigaction system call handler for signal management within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signals_Exit | Signals_Exit | 328 | 349 | Handles system-level signal handling and process termination events. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sigaction | sigaction | 333 | 333 | Implements the sigaction system call handler for signal management within the ngIRCd daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_NotifySvcMgr_Possible | Signal_NotifySvcMgr_Possible | 356 | 364 | A global function that likely manages signal notification services, handling system-level event delivery or inter-process communication. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | main | main | 228 | 372 | Entry point function responsible for initializing the application and setting up the command-line interface. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Panic | Panic | 26 | 32 | A static function used for panic handling, likely responsible for terminating the server process or triggering a crash during portability testing. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | main | main | 179 | 204 | Entry point function for the ngIRCd portability test suite, responsible for initializing and running the portability test infrastructure. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\waitpid.c | function | waitpid | waitpid | 19 | 28 | Implements the waitpid system call to manage process state and wait for child processes. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ipaddr\ng_ipaddr.c | function | ng_ipaddr_init | ng_ipaddr_init | 23 | 77 |  |  |  | GLOBAL bool ng_ipaddr_init(ng_ipaddr_t *addr, const char *ip_str, UINT16 port)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Init | Channel_Init | 59 | 64 |  |  |  | GLOBAL void Channel_Init( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_InitPredefined | Channel_InitPredefined | 94 | 202 |  |  |  | GLOBAL void Channel_InitPredefined( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_Exit | Channel_Exit | 218 | 239 |  |  |  | GLOBAL void Channel_Exit( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Channel_LogServer | Channel_LogServer | 1255 | 1269 |  |  |  | GLOBAL void Channel_LogServer(const char *msg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_Init | Class_Init | 30 | 34 |  |  |  | GLOBAL void Class_Init(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_Exit | Class_Exit | 36 | 42 |  |  |  | GLOBAL void Class_Exit(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\class.c | function | Class_GetMemberReason | Class_GetMemberReason | 44 | 69 |  |  |  | GLOBAL bool Class_GetMemberReason(const int Class, CLIENT *Client, char *reason, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Init | Client_Init | 71 | 103 |  |  |  | GLOBAL void Client_Init( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_Exit | Client_Exit | 106 | 126 |  |  |  | GLOBAL void Client_Exit( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_HostnameDisplayed | Client_HostnameDisplayed | 773 | 788 |  |  |  | GLOBAL char * Client_HostnameDisplayed(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_ServerCount | Client_ServerCount | 1124 | 1128 |  |  |  | GLOBAL long Client_ServerCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_MyServerCount | Client_MyServerCount | 1145 | 1158 |  |  |  | GLOBAL unsigned long Client_MyServerCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_OperCount | Client_OperCount | 1161 | 1175 |  |  |  | GLOBAL unsigned long Client_OperCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_UnknownCount | Client_UnknownCount | 1178 | 1192 |  |  |  | GLOBAL unsigned long Client_UnknownCount( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_StartTime | Client_StartTime | 1265 | 1270 |  |  |  | GLOBAL time_t Client_StartTime(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Free_Client | Free_Client | 1411 | 1428 |  |  |  | static void Free_Client(CLIENT **Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Adjust_Counters | Adjust_Counters | 1454 | 1471 |  |  |  | static void Adjust_Counters( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Destroy_UserOrService | Destroy_UserOrService | 1541 | 1585 |  |  |  | static void Destroy_UserOrService(CLIENT *Client, const char *Txt, const char *FwdMsg, bool SendQuit)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | opers_free | opers_free | 291 | 304 |  |  |  | static void opers_free(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | field | refcnt | refcnt | 70 | 70 |  | int | scalar_or_unknown | int refcnt;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogMalloc | LogMalloc | 887 | 895 |  |  |  | static void * LogMalloc(size_t s)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | my_sd_listen_fds | my_sd_listen_fds | 135 | 157 |  |  |  | static int my_sd_listen_fds(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_ExitListeners | Conn_ExitListeners | 527 | 551 |  |  |  | GLOBAL void Conn_ExitListeners( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_CountMax | Conn_CountMax | 1199 | 1203 |  |  |  | GLOBAL long Conn_CountMax(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SyncServerStruct | Conn_SyncServerStruct | 1220 | 1245 |  |  |  | GLOBAL void Conn_SyncServerStruct(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Init_Conn_Struct | Init_Conn_Struct | 2136 | 2152 |  |  |  | static void Init_Conn_Struct(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_devpoll | io_close_devpoll | 227 | 234 |  |  |  | static void io_close_devpoll(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_devpoll | io_library_init_devpoll | 236 | 244 |  |  |  | static void io_library_init_devpoll(unsigned int eventsize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_devpoll | io_close_devpoll | 246 | 248 |  |  |  | static inline void io_close_devpoll(int UNUSED x)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_devpoll | io_library_init_devpoll | 249 | 251 |  |  |  | static inline void io_library_init_devpoll(unsigned int UNUSED ev)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_poll | io_library_init_poll | 335 | 352 |  |  |  | static void io_library_init_poll(unsigned int eventsize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_poll | io_close_poll | 354 | 356 |  |  |  | static inline void io_close_poll(int UNUSED x)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_poll | io_library_init_poll | 357 | 359 |  |  |  | static inline void io_library_init_poll(unsigned int UNUSED ev)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_select | io_library_init_select | 402 | 424 |  |  |  | static void io_library_init_select(unsigned int eventsize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_select | io_library_init_select | 449 | 451 |  |  |  | static inline void io_library_init_select(int UNUSED x)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_close_select | io_close_select | 452 | 454 |  |  |  | static inline void io_close_select(int UNUSED x)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_epoll | io_library_init_epoll | 503 | 520 |  |  |  | static void io_library_init_epoll(unsigned int eventsize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_epoll | io_library_init_epoll | 522 | 524 |  |  |  | static inline void io_library_init_epoll(unsigned int UNUSED ev)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_event_kqueue_commit_cache | io_event_kqueue_commit_cache | 529 | 554 |  |  |  | static bool io_event_kqueue_commit_cache(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_kqueue | io_library_init_kqueue | 630 | 640 |  |  |  | static void io_library_init_kqueue(unsigned int eventsize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init_kqueue | io_library_init_kqueue | 642 | 644 |  |  |  | static inline void io_library_init_kqueue(unsigned int UNUSED ev)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_init | io_library_init | 648 | 664 |  |  |  | bool io_library_init(unsigned int eventsize)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_library_shutdown | io_library_shutdown | 667 | 683 |  |  |  | void io_library_shutdown(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_setnonblock | io_setnonblock | 795 | 807 |  |  |  | bool io_setnonblock(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_setcloexec | io_setcloexec | 809 | 820 |  |  |  | bool io_setcloexec(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Parse_CAP | Parse_CAP | 57 | 87 |  |  |  | static int Parse_CAP(int Capabilities, char *Args)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | uptime_days | uptime_days | 58 | 62 |  |  |  | static unsigned int uptime_days(time_t *now)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | write_whoreply | write_whoreply | 76 | 84 |  |  |  | static bool write_whoreply(CLIENT *Client, CLIENT *c, const char *channelname, const char *flags)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | who_flags_qualifier | who_flags_qualifier | 95 | 128 |  |  |  | static char * who_flags_qualifier(CLIENT *Client, const char *chan_user_modes, char *str, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | Show_MOTD_SSLInfo | Show_MOTD_SSLInfo | 457 | 480 |  |  |  | static bool Show_MOTD_SSLInfo(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | Show_MOTD_SSLInfo | Show_MOTD_SSLInfo | 482 | 486 |  |  |  | static bool Show_MOTD_SSLInfo(UNUSED CLIENT *c)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_ADMIN | IRC_ADMIN | 498 | 530 |  |  |  | GLOBAL bool IRC_ADMIN(CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | IRC_Show_MOTD | IRC_Show_MOTD | 1447 | 1487 |  |  |  | GLOBAL bool IRC_Show_MOTD( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-mode.c | function | Del_From_List | Del_From_List | 1084 | 1115 |  |  |  | static bool Del_From_List(char what, CLIENT *Prefix, CLIENT *Client, CHANNEL *Channel, const char *Pattern)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | Bad_OperPass | Bad_OperPass | 47 | 56 |  |  |  | static bool Bad_OperPass(CLIENT *Client, char *errtoken, char *errmsg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_DIE | IRC_DIE | 110 | 141 |  |  |  | GLOBAL bool IRC_DIE(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-oper.c | function | IRC_RESTART | IRC_RESTART | 177 | 193 |  |  |  | GLOBAL bool IRC_RESTART( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | IRC_TRACE | IRC_TRACE | 227 | 295 |  |  |  | GLOBAL bool IRC_TRACE(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc.c | function | Help | Help | 421 | 477 |  |  |  | static bool Help(CLIENT *Client, const char *Topic)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_Free | Lists_Free | 230 | 247 |  |  |  | GLOBAL void Lists_Free(struct list_head *head)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Init_Subprocess | Log_Init_Subprocess | 206 | 214 |  |  |  | GLOBAL void Log_Init_Subprocess(char UNUSED *Name)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | main | main | 73 | 333 |  |  |  | GLOBAL int main(int argc, const char *argv[])
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Fill_Version | Fill_Version | 344 | 448 |  |  |  | static void Fill_Version(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Show_Version | Show_Version | 454 | 462 |  |  |  | static void Show_Version( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Pidfile_Delete | Pidfile_Delete | 492 | 502 |  |  |  | static void Pidfile_Delete( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Pidfile_Create | Pidfile_Create | 510 | 542 |  |  |  | static void Pidfile_Create(pid_t pid)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Setup_FDStreams | Setup_FDStreams | 550 | 561 |  |  |  | static void Setup_FDStreams(int fd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Random_Init | Random_Init | 609 | 613 |  |  |  | static void Random_Init(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Random_Init_Kern | Random_Init_Kern | 615 | 628 |  |  |  | static bool Random_Init_Kern(const char *file)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Random_Init | Random_Init | 633 | 643 |  |  |  | static void Random_Init(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | NGIRCd_Init | NGIRCd_Init | 654 | 836 |  |  |  | static bool NGIRCd_Init(bool NGIRCd_NoDaemon)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Parse_GetCommandStruct | Parse_GetCommandStruct | 150 | 154 |  |  |  | GLOBAL COMMAND * Parse_GetCommandStruct( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Init_Request | Init_Request | 275 | 286 |  |  |  | static void Init_Request( REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\parse.c | function | Validate_Prefix | Validate_Prefix | 289 | 363 |  |  |  | static bool Validate_Prefix( CONN_ID Idx, REQUEST *Req, bool *Closed )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_InitStruct | Proc_InitStruct | 37 | 43 |  |  |  | GLOBAL void Proc_InitStruct (PROC_STAT *proc)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_Fork | Proc_Fork | 48 | 107 |  |  |  | GLOBAL pid_t Proc_Fork(PROC_STAT *proc, int *pipefds, void (*cbfunc)(int, short), int timeout)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_GenericSignalHandler | Proc_GenericSignalHandler | 112 | 123 |  |  |  | GLOBAL void Proc_GenericSignalHandler(int Signal)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_Read | Proc_Read | 130 | 153 |  |  |  | GLOBAL size_t Proc_Read(PROC_STAT *proc, void *buffer, size_t buflen)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\proc.c | function | Proc_Close | Proc_Close | 158 | 166 |  |  |  | GLOBAL void Proc_Close(PROC_STAT *proc)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Dump_State | Dump_State | 50 | 64 |  |  |  | static void Dump_State(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Block | Signal_Block | 67 | 80 |  |  |  | static void Signal_Block(int sig)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Unblock | Signal_Unblock | 82 | 96 |  |  |  | static void Signal_Unblock(int sig)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Handler | Signal_Handler | 161 | 215 |  |  |  | static void Signal_Handler(int Signal)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Handler_BH | Signal_Handler_BH | 226 | 245 |  |  |  | static void Signal_Handler_BH(int Signal)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_Callback | Signal_Callback | 247 | 270 |  |  |  | static void Signal_Callback(int fd, short UNUSED what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signals_Init | Signals_Init | 277 | 319 |  |  |  | bool Signals_Init(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sigaction | sigaction | 282 | 282 |  |  |  | struct sigaction
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signals_Exit | Signals_Exit | 328 | 349 |  |  |  | void Signals_Exit(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | struct | sigaction | sigaction | 333 | 333 |  |  |  | struct sigaction
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Signal_NotifySvcMgr_Possible | Signal_NotifySvcMgr_Possible | 356 | 364 |  |  |  | GLOBAL bool Signal_NotifySvcMgr_Possible(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | main | main | 228 | 372 |  |  |  | int main(argc, argv) int argc; char *argv[];
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Panic | Panic | 26 | 32 |  |  |  | static void Panic(char *Reason)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | main | main | 179 | 204 |  |  |  | GLOBAL int main(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\waitpid.c | function | waitpid | waitpid | 19 | 28 |  |  |  | GLOBAL int waitpid(pid, stat_loc, options) int pid, *stat_loc, options;
```

## Component: Configuration
- Category: technical
- Assigned symbols: 62

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | SSLOptions | SSLOptions | 106 | 106 | Defines the structure and fields for SSL/TLS configuration options used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | ConfSSL_Init | ConfSSL_Init | 111 | 134 | Initializes SSL/TLS configuration settings for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_SSLInUse | Conf_SSLInUse | 141 | 156 | A global function that returns a boolean indicating whether SSL is enabled for the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | ports_puts | ports_puts | 203 | 218 | Handles configuration data structures and initialization settings for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | ports_parse | ports_parse | 223 | 248 | Parses configuration file entries for network ports and other settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_Init | Conf_Init | 253 | 258 | Initializes the configuration structure and loads settings from the specified file. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_Rehash | Conf_Rehash | 265 | 275 | A function responsible for rehashing configuration data, likely updating or reorganizing internal configuration structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | yesno_to_str | yesno_to_str | 280 | 286 | Converts boolean values to string representations for configuration settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 294 | 294 | Defines the structure and fields for configuration operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | opers_puts | opers_puts | 309 | 326 | Handles configuration file parsing and initialization settings for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 312 | 312 | Defines the structure and fields for configuration operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_Test | Conf_Test | 337 | 515 | A function used to test or validate configuration settings within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_UnsetServer | Conf_UnsetServer | 525 | 561 | Function responsible for clearing or resetting server configuration settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_SetServer | Conf_SetServer | 566 | 583 | Function responsible for setting the server configuration value. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_GetServer | Conf_GetServer | 588 | 599 | Retrieves the server configuration value associated with the provided connection ID. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_EnableServer | Conf_EnableServer | 607 | 622 | Function that enables a specific server configuration option by name and port. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_EnablePassiveServer | Conf_EnablePassiveServer | 633 | 649 | Function that enables or disables the passive server feature within the ngIRCd configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_DisableServer | Conf_DisableServer | 657 | 675 | Function that disables a specific server configuration option. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_AddServer | Conf_AddServer | 687 | 714 | Function responsible for adding a new server configuration entry to the ngIRCd server settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_NickIsService | Conf_NickIsService | 723 | 731 | Function that determines whether a nickname is treated as a service identifier within the configuration context. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_NickIsBlocked | Conf_NickIsBlocked | 739 | 751 | Function that checks if a user nickname is blocked based on configuration settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Set_Defaults | Set_Defaults | 756 | 849 | Sets default configuration values for the ngIRCd server based on the initialization flag. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | no_listenports | no_listenports | 856 | 864 | A static function that likely returns a boolean indicating whether the server should listen on any network ports. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Read_TextFile | Read_TextFile | 874 | 905 | Reads configuration file content into a destination array for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Read_Config | Read_Config | 917 | 1096 | Reads configuration options and settings from the specified file. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 1185 | 1185 | Defines the structure and fields for configuration operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 1187 | 1187 | Defines the structure and fields for configuration operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_OPTIONS | Handle_OPTIONS | 1583 | 1788 | Handles parsing of configuration file arguments and environment variables for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_OPERATOR | Handle_OPERATOR | 1868 | 1906 | Handles parsing and validation of configuration file variables and arguments. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 1872 | 1872 | Defines the structure and fields for configuration operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_SERVER | Handle_SERVER | 1915 | 2012 | Handles server configuration parameters and file-based settings for the ngIRCd daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_Channelname | Handle_Channelname | 2024 | 2040 | Handles parsing and validation of channel name configuration parameters. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_CHANNEL | Handle_CHANNEL | 2049 | 2122 | Handles parsing and validation of channel configuration parameters from the source file. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Validate_Config | Validate_Config | 2134 | 2292 | Validates the configuration parameters and hash settings for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 2287 | 2287 | Defines the structure and fields for configuration operations within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error_TooLong | Config_Error_TooLong | 2300 | 2305 | Handles error conditions related to configuration file parsing and validation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error_Section | Config_Error_Section | 2314 | 2320 | Handles error reporting and configuration section validation for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error_NaN | Config_Error_NaN | 2328 | 2333 | Handles error reporting for configuration parameters and file paths. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error | Config_Error | 2348 | 2374 | A static function used to handle configuration errors, likely part of the ngIRCd configuration loading or validation process. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_DebugDump | Conf_DebugDump | 2380 | 2396 | Debug dump function for logging internal configuration details. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Init_Server_Struct | Init_Server_Struct | 2404 | 2424 | Initializes the server structure using configuration data. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | name | Conf_Oper::name | 37 | 37 | Defines the configuration structure and field layout for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | pwd | Conf_Oper::pwd | 38 | 38 | Defines the password field structure and type for the Conf_Oper class. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | mask | Conf_Oper::mask | 39 | 39 | Defines the structure and type of configuration options, specifically the mask field used for permission operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | _Conf_Server | _Conf_Server | 47 | 68 | Defines server configuration parameters such as hostname, client ID, password, and port for the ngIRCd daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | host | _Conf_Server::host | 49 | 49 | Defines the server's host configuration field within the ngIRCd daemon's header file. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | pwd_in | _Conf_Server::pwd_in | 51 | 51 | Defines the structure and type of the password input field within the server's configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | port | _Conf_Server::port | 53 | 53 | Defines the port configuration for the _Conf_Server domain model. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | group | _Conf_Server::group | 54 | 54 | Defines server configuration parameters and data structures for the ngIRCd daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | flags | _Conf_Server::flags | 57 | 57 | Defines server configuration flags and properties for the ngIRCd daemon. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | bind_addr | _Conf_Server::bind_addr | 59 | 59 | Defines the server's network binding address and type. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | SSLConnect | _Conf_Server::SSLConnect | 63 | 63 | Defines a boolean configuration option for SSL connection handling within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | SSLVerify | _Conf_Server::SSLVerify | 64 | 64 | Defines a boolean configuration option for SSL verification on the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | SSLOptions | SSLOptions | 73 | 82 | Defines SSL/TLS connection parameters and file paths for secure communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | KeyFile | SSLOptions::KeyFile | 74 | 74 | Defines the structure and type of SSL/TLS configuration options for the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | ListenPorts | SSLOptions::ListenPorts | 77 | 77 | Defines the configuration options and data structures for the ngIRCd server, including SSL/TLS settings. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | KeyFilePassword | SSLOptions::KeyFilePassword | 78 | 78 | Defines SSL/TLS security options for the ngIRCd server, including the key file password. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CRLFile | SSLOptions::CRLFile | 81 | 81 | Defines the structure and type of SSL options used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | key | Conf_Channel::key | 90 | 90 | Defines the configuration key and data type for the channel name field within the ngIRCd server configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | keyfile | Conf_Channel::keyfile | 92 | 92 | Defines the configuration structure for the Conf_Channel component, specifying the keyfile field type and size. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | autojoin | Conf_Channel::autojoin | 93 | 93 | Defines a boolean configuration option for autojoining channels. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | modes_num | Conf_Channel::modes_num | 95 | 95 | Defines the data structure and field type for the configuration channel mode count. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | SSLOptions | SSLOptions | 106 | 106 |  |  |  | struct SSLOptions
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | ConfSSL_Init | ConfSSL_Init | 111 | 134 |  |  |  | static void ConfSSL_Init(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_SSLInUse | Conf_SSLInUse | 141 | 156 |  |  |  | GLOBAL bool Conf_SSLInUse(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | ports_puts | ports_puts | 203 | 218 |  |  |  | static void ports_puts(array *a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | ports_parse | ports_parse | 223 | 248 |  |  |  | static void ports_parse(array *a, const char *File, int Line, char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_Init | Conf_Init | 253 | 258 |  |  |  | GLOBAL void Conf_Init( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_Rehash | Conf_Rehash | 265 | 275 |  |  |  | GLOBAL bool Conf_Rehash( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | yesno_to_str | yesno_to_str | 280 | 286 |  |  |  | static const char* yesno_to_str(int boolean_value)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 294 | 294 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | opers_puts | opers_puts | 309 | 326 |  |  |  | static void opers_puts(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 312 | 312 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_Test | Conf_Test | 337 | 515 |  |  |  | GLOBAL int Conf_Test( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_UnsetServer | Conf_UnsetServer | 525 | 561 |  |  |  | GLOBAL void Conf_UnsetServer( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_SetServer | Conf_SetServer | 566 | 583 |  |  |  | GLOBAL bool Conf_SetServer( int ConfServer, CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_GetServer | Conf_GetServer | 588 | 599 |  |  |  | GLOBAL int Conf_GetServer( CONN_ID Idx )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_EnableServer | Conf_EnableServer | 607 | 622 |  |  |  | GLOBAL bool Conf_EnableServer( const char *Name, UINT16 Port )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_EnablePassiveServer | Conf_EnablePassiveServer | 633 | 649 |  |  |  | GLOBAL bool Conf_EnablePassiveServer(const char *Name)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_DisableServer | Conf_DisableServer | 657 | 675 |  |  |  | GLOBAL bool Conf_DisableServer( const char *Name )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_AddServer | Conf_AddServer | 687 | 714 |  |  |  | GLOBAL bool Conf_AddServer(const char *Name, UINT16 Port, const char *Host, const char *MyPwd, const char *PeerPwd)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_NickIsService | Conf_NickIsService | 723 | 731 |  |  |  | GLOBAL bool Conf_NickIsService(int ConfServer, const char *Nick)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_NickIsBlocked | Conf_NickIsBlocked | 739 | 751 |  |  |  | GLOBAL bool Conf_NickIsBlocked(const char *Nick)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Set_Defaults | Set_Defaults | 756 | 849 |  |  |  | static void Set_Defaults(bool InitServers)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | no_listenports | no_listenports | 856 | 864 |  |  |  | static bool no_listenports(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Read_TextFile | Read_TextFile | 874 | 905 |  |  |  | static bool Read_TextFile(const char *Filename, const char *Name, array *Destination)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Read_Config | Read_Config | 917 | 1096 |  |  |  | static bool Read_Config(bool TestOnly, bool IsStarting)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 1185 | 1185 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 1187 | 1187 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_OPTIONS | Handle_OPTIONS | 1583 | 1788 |  |  |  | static void Handle_OPTIONS(const char *File, int Line, char *Var, char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_OPERATOR | Handle_OPERATOR | 1868 | 1906 |  |  |  | static void Handle_OPERATOR(const char *File, int Line, char *Var, char *Arg )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 1872 | 1872 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_SERVER | Handle_SERVER | 1915 | 2012 |  |  |  | static void Handle_SERVER(const char *File, int Line, char *Var, char *Arg )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_Channelname | Handle_Channelname | 2024 | 2040 |  |  |  | static bool Handle_Channelname(struct Conf_Channel *new_chan, const char *name)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_CHANNEL | Handle_CHANNEL | 2049 | 2122 |  |  |  | static void Handle_CHANNEL(const char *File, int Line, char *Var, char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Validate_Config | Validate_Config | 2134 | 2292 |  |  |  | static bool Validate_Config(bool Configtest, bool Rehash)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | struct | Conf_Oper | Conf_Oper | 2287 | 2287 |  |  |  | struct Conf_Oper
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error_TooLong | Config_Error_TooLong | 2300 | 2305 |  |  |  | static void Config_Error_TooLong(const char *File, const int Line, const char *Item)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error_Section | Config_Error_Section | 2314 | 2320 |  |  |  | static void Config_Error_Section(const char *File, const int Line, const char *Item, const char *Section)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error_NaN | Config_Error_NaN | 2328 | 2333 |  |  |  | static void Config_Error_NaN(const char *File, const int Line, const char *Item )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Config_Error | Config_Error | 2348 | 2374 |  |  |  | static void Config_Error( Level, Format, va_alist ) const int Level; const char *Format; va_dcl #endif
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Conf_DebugDump | Conf_DebugDump | 2380 | 2396 |  |  |  | GLOBAL void Conf_DebugDump(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Init_Server_Struct | Init_Server_Struct | 2404 | 2424 |  |  |  | static void Init_Server_Struct( CONF_SERVER *Server )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | name | Conf_Oper::name | 37 | 37 | Conf_Oper | char | scalar_or_unknown | char name[CLIENT_PASS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | pwd | Conf_Oper::pwd | 38 | 38 | Conf_Oper | char | scalar_or_unknown | char pwd[CLIENT_PASS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | mask | Conf_Oper::mask | 39 | 39 | Conf_Oper | char | scalar_or_unknown | char *mask;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | _Conf_Server | _Conf_Server | 47 | 68 |  |  |  | struct _Conf_Server { char host[HOST_LEN]; /**< Hostname */ char name[CLIENT_ID_LEN]; /**< IRC client ID */ char pwd_in[CLIENT_PASS_LEN]; /**< Password which must be received */ char pwd_out[CLIENT_PASS_LEN]; /**< Password to send to the peer */ UINT16 port; /**< Server port to connect to */ int gro
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | host | _Conf_Server::host | 49 | 49 | _Conf_Server | char | scalar_or_unknown | char host[HOST_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | pwd_in | _Conf_Server::pwd_in | 51 | 51 | _Conf_Server | char | scalar_or_unknown | char pwd_in[CLIENT_PASS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | port | _Conf_Server::port | 53 | 53 | _Conf_Server | UINT16 | scalar_or_unknown | UINT16 port;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | group | _Conf_Server::group | 54 | 54 | _Conf_Server | int | scalar_or_unknown | int group;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | flags | _Conf_Server::flags | 57 | 57 | _Conf_Server | int | scalar_or_unknown | int flags;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | bind_addr | _Conf_Server::bind_addr | 59 | 59 | _Conf_Server | ng_ipaddr_t | scalar_or_unknown | ng_ipaddr_t bind_addr;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | SSLConnect | _Conf_Server::SSLConnect | 63 | 63 | _Conf_Server | bool | scalar_or_unknown | bool SSLConnect;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | SSLVerify | _Conf_Server::SSLVerify | 64 | 64 | _Conf_Server | bool | scalar_or_unknown | bool SSLVerify;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | struct | SSLOptions | SSLOptions | 73 | 82 |  |  |  | struct SSLOptions { char *KeyFile; /**< SSL key file */ char *CertFile; /**< SSL certificate file */ char *DHFile; /**< File containing DH parameters */ array ListenPorts; /**< Array of listening SSL ports */ array KeyFilePassword; /**< Key file password */ char *CipherList; /**< Set SSL cipher list
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | KeyFile | SSLOptions::KeyFile | 74 | 74 | SSLOptions | char | scalar_or_unknown | char *KeyFile;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | ListenPorts | SSLOptions::ListenPorts | 77 | 77 | SSLOptions | array | array_or_collection | array ListenPorts;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | KeyFilePassword | SSLOptions::KeyFilePassword | 78 | 78 | SSLOptions | array | array_or_collection | array KeyFilePassword;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CRLFile | SSLOptions::CRLFile | 81 | 81 | SSLOptions | char | scalar_or_unknown | char *CRLFile;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | key | Conf_Channel::key | 90 | 90 | Conf_Channel | char | scalar_or_unknown | char key[CLIENT_PASS_LEN];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | keyfile | Conf_Channel::keyfile | 92 | 92 | Conf_Channel | char | scalar_or_unknown | char keyfile[512];
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | autojoin | Conf_Channel::autojoin | 93 | 93 | Conf_Channel | bool | scalar_or_unknown | bool autojoin;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | modes_num | Conf_Channel::modes_num | 95 | 95 | Conf_Channel | unsigned int | scalar_or_unknown | unsigned int modes_num;
```

## Component: Security / Authentication / Authorization
- Category: technical
- Assigned symbols: 34

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Set_KeyFile | Set_KeyFile | 1379 | 1404 | Handles key file management for channel authentication and encryption. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Generate_MyToken | Generate_MyToken | 1430 | 1451 | Generates a cryptographic token for client authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_SSL | Handle_SSL | 1799 | 1857 | Handles SSL/TLS connection initialization and secure communication setup. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CertFile | SSLOptions::CertFile | 75 | 75 | Defines the SSL certificate file path and options used for secure client-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | DHFile | SSLOptions::DHFile | 76 | 76 | Defines the structure for SSL/TLS certificate and key handling options within the server configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CipherList | SSLOptions::CipherList | 79 | 79 | Defines the cipher list used for SSL/TLS encryption and decryption of network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CAFile | SSLOptions::CAFile | 80 | 80 | SSL/TLS certificate file path configuration for secure communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | struct | SSLOptions | SSLOptions | 40 | 40 | Defines the structure for SSL/TLS connection options used to secure the server's network communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogOpenSSL_CertInfo | LogOpenSSL_CertInfo | 143 | 168 | Handles SSL certificate logging and verification within the server's security infrastructure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogOpenSSLError | LogOpenSSLError | 170 | 184 | Handles SSL/TLS error logging for secure network connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | pem_passwd_cb | pem_passwd_cb | 187 | 208 | Implements the PEM password callback function for SSL/TLS certificate and key authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | Load_DH_params | Load_DH_params | 235 | 303 | Implements SSL/TLS key exchange parameters for secure server-to-client and server-to-server communication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogGnuTLS_CertInfo | LogGnuTLS_CertInfo | 898 | 934 | Handles logging of GnuTLS certificate information during SSL/TLS connection establishment. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | SSLOptions | SSLOptions | 111 | 111 | Defines SSL/TLS configuration options for secure client-server and server-server links. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetCertFp | Conn_GetCertFp | 2710 | 2717 | Retrieves the certificate fingerprint for the given connection ID, a critical step in establishing secure SSL/TLS connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetCertFp | Conn_SetCertFp | 2719 | 2726 | Handles certificate fingerprinting for SSL/TLS client and server connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetCertFp | Conn_GetCertFp | 2736 | 2740 | Function responsible for retrieving the certificate fingerprint for connection security. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetCertFp | Conn_SetCertFp | 2742 | 2746 | Function responsible for setting the client's certificate fingerprint for SSL/TLS connection verification. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Set_CAP_Negotiation | Set_CAP_Negotiation | 41 | 49 | Handles negotiation of client capabilities and authentication parameters. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_PASS | IRC_PASS | 49 | 162 | Handles the authentication logic for IRC clients by validating credentials and managing the login request. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_NICK | IRC_NICK | 171 | 366 | Handles user login and nickname assignment for IRC clients. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | if | if | 483 | 509 | Validates client type against allowed server or service categories for login access. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | if | if | 509 | 513 | Checks if the client is a user type to validate identity before allowing login. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_SERVICE | IRC_SERVICE | 531 | 609 | Handles client login requests and validates user credentials. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | Login_User | Login_User | 61 | 144 | Handles user login and authentication logic for the IRC client connection. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | Login_User_PostAuth | Login_User_PostAuth | 155 | 211 | Handles user authentication and post-authentication logic for client connections. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | cb_Read_Auth_Result | cb_Read_Auth_Result | 250 | 296 | Handles authentication result callbacks for user login and session validation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\op.c | function | Op_NoPrivileges | Op_NoPrivileges | 34 | 55 | Function that checks if a client has sufficient privileges to perform an operation, enforcing access control rules. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | function | password_conversation | password_conversation | 46 | 75 | Implements PAM (Pluggable Authentication Modules) password conversation logic for user authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_message | pam_message | 47 | 47 | Defines the structure for authentication messages used by the Pluggable Authentication Modules (PAM) system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_response | pam_response | 48 | 48 | Defines the data structure used to store authentication response information for the PAM module. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_response | pam_response | 65 | 65 | Defines the structure for authentication response data used by the Pluggable Authentication Modules (PAM) system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_conv | pam_conv | 80 | 80 | Implements the PAM (Pluggable Authentication Modules) conversion structure for user authentication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | function | PAM_Authenticate | PAM_Authenticate | 90 | 134 | Implements the PAM (Pluggable Authentication Modules) authentication mechanism for user login and identity verification. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ngircd\channel.c | function | Set_KeyFile | Set_KeyFile | 1379 | 1404 |  |  |  | static void Set_KeyFile(CHANNEL *Chan, const char *KeyFile)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Generate_MyToken | Generate_MyToken | 1430 | 1451 |  |  |  | static void Generate_MyToken( CLIENT *Client )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | Handle_SSL | Handle_SSL | 1799 | 1857 |  |  |  | static void Handle_SSL(const char *File, int Line, char *Var, char *Arg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CertFile | SSLOptions::CertFile | 75 | 75 | SSLOptions | char | scalar_or_unknown | char *CertFile;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | DHFile | SSLOptions::DHFile | 76 | 76 | SSLOptions | char | scalar_or_unknown | char *DHFile;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CipherList | SSLOptions::CipherList | 79 | 79 | SSLOptions | char | scalar_or_unknown | char *CipherList;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.h | field | CAFile | SSLOptions::CAFile | 80 | 80 | SSLOptions | char | scalar_or_unknown | char *CAFile;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | struct | SSLOptions | SSLOptions | 40 | 40 |  |  |  | struct SSLOptions
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogOpenSSL_CertInfo | LogOpenSSL_CertInfo | 143 | 168 |  |  |  | static void LogOpenSSL_CertInfo(int level, X509 * cert, const char *msg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogOpenSSLError | LogOpenSSLError | 170 | 184 |  |  |  | static void LogOpenSSLError(const char *error, const char *info)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | pem_passwd_cb | pem_passwd_cb | 187 | 208 |  |  |  | static int pem_passwd_cb(char *buf, int size, int rwflag, void *password)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | Load_DH_params | Load_DH_params | 235 | 303 |  |  |  | static bool Load_DH_params(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn-ssl.c | function | LogGnuTLS_CertInfo | LogGnuTLS_CertInfo | 898 | 934 |  |  |  | static void LogGnuTLS_CertInfo(int level, gnutls_x509_crt_t cert, const char *msg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | struct | SSLOptions | SSLOptions | 111 | 111 |  |  |  | struct SSLOptions
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetCertFp | Conn_GetCertFp | 2710 | 2717 |  |  |  | GLOBAL char * Conn_GetCertFp(CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetCertFp | Conn_SetCertFp | 2719 | 2726 |  |  |  | GLOBAL bool Conn_SetCertFp(CONN_ID Idx, const char *fingerprint)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_GetCertFp | Conn_GetCertFp | 2736 | 2740 |  |  |  | GLOBAL char * Conn_GetCertFp(UNUSED CONN_ID Idx)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_SetCertFp | Conn_SetCertFp | 2742 | 2746 |  |  |  | GLOBAL bool Conn_SetCertFp(UNUSED CONN_ID Idx, UNUSED const char *fingerprint)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Set_CAP_Negotiation | Set_CAP_Negotiation | 41 | 49 |  |  |  | static void Set_CAP_Negotiation(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_PASS | IRC_PASS | 49 | 162 |  |  |  | GLOBAL bool IRC_PASS( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_NICK | IRC_NICK | 171 | 366 |  |  |  | GLOBAL bool IRC_NICK( CLIENT *Client, REQUEST *Req )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | if | if | 483 | 509 |  |  |  | else if (Client_Type(Client) == CLIENT_SERVER || Client_Type(Client) == CLIENT_SERVICE)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | if | if | 509 | 513 |  |  |  | else if (Client_Type(Client) == CLIENT_USER)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-login.c | function | IRC_SERVICE | IRC_SERVICE | 531 | 609 |  |  |  | GLOBAL bool IRC_SERVICE(CLIENT *Client, REQUEST *Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | Login_User | Login_User | 61 | 144 |  |  |  | GLOBAL bool Login_User(CLIENT * Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | Login_User_PostAuth | Login_User_PostAuth | 155 | 211 |  |  |  | GLOBAL bool Login_User_PostAuth(CLIENT *Client)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\login.c | function | cb_Read_Auth_Result | cb_Read_Auth_Result | 250 | 296 |  |  |  | static void cb_Read_Auth_Result(int r_fd, UNUSED short events)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\op.c | function | Op_NoPrivileges | Op_NoPrivileges | 34 | 55 |  |  |  | GLOBAL bool Op_NoPrivileges(CLIENT * Client, REQUEST * Req)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | function | password_conversation | password_conversation | 46 | 75 |  |  |  | static int password_conversation(int num_msg, const struct pam_message **msg, struct pam_response **resp, void *appdata_ptr)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_message | pam_message | 47 | 47 |  |  |  | struct pam_message
C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_response | pam_response | 48 | 48 |  |  |  | struct pam_response
C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_response | pam_response | 65 | 65 |  |  |  | struct pam_response
C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | struct | pam_conv | pam_conv | 80 | 80 |  |  |  | struct pam_conv
C:\develop\SpecBuilder\ngircd-master\src\ngircd\pam.c | function | PAM_Authenticate | PAM_Authenticate | 90 | 134 |  |  |  | GLOBAL bool PAM_Authenticate(CLIENT *Client)
```

## Component: Logging / Monitoring
- Category: technical
- Assigned symbols: 7

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Message | Log_Message | 45 | 59 | Implements the function responsible for logging messages with a specific log level. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Init | Log_Init | 68 | 84 | Initializes the logging system for the ngIRCd server, handling configuration for syslog mode. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_ReInit | Log_ReInit | 90 | 100 | Initializes the logging subsystem for the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Exit | Log_Exit | 103 | 112 | Handles cleanup and exit procedures for the logging system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Exit_Subprocess | Log_Exit_Subprocess | 217 | 225 | Handles cleanup and exit procedures for log subsystems, ensuring proper termination of logging operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Log_Forgery_NoIP | Log_Forgery_NoIP | 327 | 333 | A function responsible for logging a specific error condition regarding IP address forgery. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Log_Forgery_WrongIP | Log_Forgery_WrongIP | 335 | 341 | A function responsible for logging a specific error condition regarding a forged IP address. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Message | Log_Message | 45 | 59 |  |  |  | static void Log_Message(int Level, const char *msg)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Init | Log_Init | 68 | 84 |  |  |  | GLOBAL void Log_Init(bool Syslog_Mode)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_ReInit | Log_ReInit | 90 | 100 |  |  |  | GLOBAL void Log_ReInit(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Exit | Log_Exit | 103 | 112 |  |  |  | GLOBAL void Log_Exit( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\log.c | function | Log_Exit_Subprocess | Log_Exit_Subprocess | 217 | 225 |  |  |  | GLOBAL void Log_Exit_Subprocess(char UNUSED *Name)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Log_Forgery_NoIP | Log_Forgery_NoIP | 327 | 333 |  |  |  | static void Log_Forgery_NoIP(const char *ip, const char *host)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Log_Forgery_WrongIP | Log_Forgery_WrongIP | 335 | 341 |  |  |  | static void Log_Forgery_WrongIP(const char *ip, const char *host)
```

## Component: Utilities / Shared
- Category: technical
- Assigned symbols: 74

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | safemult_sizet | safemult_sizet | 34 | 44 | A static helper function for safe multiplication of size_t values, likely used for internal data structure calculations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_init | array_init | 47 | 54 | Helper function for initializing an array structure. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_alloc | array_alloc | 58 | 87 | Implements low-level memory allocation functions for dynamic arrays. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_copy | array_copy | 106 | 114 | Helper function for copying array data structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_copyb | array_copyb | 118 | 129 | Helper function for copying array data between pointers. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_copys | array_copys | 133 | 137 | A utility function for copying arrays, likely used for internal data manipulation within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_catb | array_catb | 142 | 179 | Helper function for concatenating arrays, likely used for internal data manipulation within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cats | array_cats | 183 | 187 | Helper function for categorizing and managing array data structures within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cat0 | array_cat0 | 191 | 195 | Helper function for concatenating arrays, likely used for internal data manipulation within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cat0_temporary | array_cat0_temporary | 199 | 208 | A helper function for temporary array concatenation used within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cat | array_cat | 211 | 218 | Helper function for concatenating array elements into a destination array. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_get | array_get | 224 | 244 | Helper function for retrieving array elements by index. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_free | array_free | 247 | 260 | Implements the free function to deallocate memory allocated for an array, handling the cleanup of the array pointer. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_free_wipe | array_free_wipe | 262 | 269 | A utility function responsible for freeing and wiping allocated memory arrays. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_trunc | array_trunc | 279 | 284 | Helper function for truncating array data structures. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_truncate | array_truncate | 287 | 297 | Helper function for managing array memory allocation and truncation. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_moveleft | array_moveleft | 301 | 329 | Helper function for moving array elements leftward, likely used for internal data manipulation within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_DebugDump | Client_DebugDump | 1696 | 1711 | A helper function used for debugging and logging purposes within the ngIRCd client. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | CheckFileReadable | CheckFileReadable | 166 | 180 | Helper function for checking file read permissions. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | strdup_warn | strdup_warn | 190 | 198 | Helper function for warning about memory allocation failures during string duplication. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_DebugDump | Conn_DebugDump | 2754 | 2771 | A helper function used for debugging and logging purposes within the ngIRCd server. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\hash.c | function | Hash | Hash | 35 | 43 | A utility function for computing a hash value from a string input. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\hash.c | function | jenkins_hash | jenkins_hash | 84 | 138 | Implements a Jenkins hash function for computing message digests. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | field | callback | callback | 36 | 36 | A callback function declaration used for external event handling or asynchronous operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | field | callback | callback | 38 | 38 | A callback function declaration used for external event handling or asynchronous operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_debug | io_debug | 148 | 152 | Helper function for debugging I/O operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_debug | io_debug | 154 | 156 | A static inline helper function used for debugging output within the ngIRCd source code. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Get_CAP_String | Get_CAP_String | 98 | 109 | Helper function for retrieving capability string values from the server configuration. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | t_diff | t_diff | 46 | 56 | Helper function for time difference calculation used by the SpecBuilder project. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | uptime_hrs | uptime_hrs | 64 | 68 | Helper function for calculating server uptime in hours. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | uptime_mins | uptime_mins | 70 | 74 | Helper function for calculating server uptime in minutes. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetReason | Lists_GetReason | 58 | 63 | Helper function for retrieving reason codes from list elements. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_MakeMask | Lists_MakeMask | 276 | 308 | Helper function for constructing a mask pattern used in list filtering operations. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | MatchCaseInsensitive | MatchCaseInsensitive | 66 | 75 | A helper function for case-insensitive pattern matching, likely used for normalizing or validating input strings within the server's logic. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Show_Help | Show_Help | 470 | 486 | A static helper function used to display help information, likely for user interaction or debugging. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Get_Error | Get_Error | 111 | 126 | Helper function for retrieving error codes from the ngIRCd error handling system. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | ArrayWrite | ArrayWrite | 344 | 355 | Helper function for writing array data to a file descriptor. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Rehash | Rehash | 101 | 151 | A helper function used for rehashing data structures, likely involved in memory management or data layout optimization within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | writeblanks | writeblanks | 448 | 457 | Helper function for writing blank characters to a buffer, likely used for formatting or encoding text output. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | test1 | test1 | 472 | 551 | A helper function for converting ANSI escape sequences to KNR (Kermit Network Remote) format. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | convert1 | convert1 | 554 | 738 | Helper function for converting ANSI escape sequences to KNR format, likely used for protocol translation or data formatting. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | POINTER | POINTER | 70 | 70 | Defines a standard type alias for pointers, serving as a reusable generic utility within the codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | socklen_t | socklen_t | 134 | 134 | Defines a standard type alias for a socket length value used in network programming. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_snprintf | Check_snprintf | 34 | 44 | A static helper function for string formatting, likely used for testing or internal utility purposes. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strdup | Check_strdup | 46 | 59 | A static helper function providing memory allocation support. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strndup | Check_strndup | 61 | 74 | A static helper function for string length checking operations. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strlcpy | Check_strlcpy | 76 | 87 | A static helper function implementing the strlcpy utility for safe string copying. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strlcat | Check_strlcat | 89 | 102 | A static helper function for string length checking operations. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strtok_r | Check_strtok_r | 104 | 129 | A static helper function for string tokenization, likely used for parsing or splitting input data within the portab module. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_vsnprintf | Check_vsnprintf | 135 | 177 | A static helper function for the portability test suite, likely used for testing or validating string formatting behavior. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\strdup.c | function | strdup | strdup | 18 | 32 | Implements the standard C library function for duplicating strings, providing a reusable utility for memory allocation. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\strlcpy.c | function | strlcat | strlcat | 30 | 47 | Implements string length manipulation functions for memory safety. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\strlcpy.c | function | strlcpy | strlcpy | 53 | 68 | A utility function for string length conversion using the standard library. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\strndup.c | function | strndup | strndup | 18 | 32 | Implements the standard string duplication function for memory management. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\strtok_r.c | function | strtok_r | strtok_r | 16 | 34 | Implements the `strtok_r` function, a utility function for safe tokenization of strings. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | void | void | 95 | 95 | Implements the `vsnprintf` function, a standard utility for safe string formatting used by the server. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | dopr | dopr | 155 | 411 | A utility function for converting character strings to fixed-width integer values using the standard C library's `vsnprintf` implementation. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | fmtstr | fmtstr | 413 | 448 | Helper function for formatting string arguments using the standard C library's snprintf implementation. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | fmtint | fmtint | 452 | 535 | Helper function for formatting integer values using the standard C library's snprintf implementation. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | abs_val | abs_val | 537 | 546 | A helper function for calculating the absolute value of a double-precision floating-point number. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | POW10 | POW10 | 548 | 559 | A helper function for calculating the 10th power of a number. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | ROUND | ROUND | 561 | 571 | A helper function for rounding floating-point values to integer types. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | my_modf | my_modf | 575 | 607 | A static helper function for converting double values to a null-terminated string using the standard C library's vsnprintf function. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | fmtfp | fmtfp | 610 | 755 | Implements a helper function for formatting floating-point values using the standard C library's `vsnprintf` function. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | dopr_outch | dopr_outch | 757 | 764 | A helper function for outputting characters to a buffer, likely used for formatting or logging within the server. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | vsnprintf | vsnprintf | 767 | 771 | Implements the standard C library function vsnprintf for safe formatted string conversion. |
| C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | snprintf | snprintf | 779 | 794 | Implements the snprintf function, a standard C library utility for safe string formatting. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_TrimStr | ngt_TrimStr | 40 | 70 | A utility function for trimming string input, likely used for data cleaning or validation within the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_UpperStr | ngt_UpperStr | 76 | 89 | A utility function for converting input strings to uppercase. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_LowerStr | ngt_LowerStr | 95 | 108 | A utility function for converting input strings to lowercase. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_TrimLastChr | ngt_TrimLastChr | 111 | 129 | A helper function for trimming the last character from a string argument. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_RandomStr | ngt_RandomStr | 135 | 158 | A helper function for generating random strings, likely used for generating unique identifiers or test data. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_SyslogFacilityName | ngt_SyslogFacilityName | 220 | 230 | A helper function for retrieving the syslog facility name, likely used for logging or system identification. |
| C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_SyslogFacilityID | ngt_SyslogFacilityID | 233 | 243 | A helper function for setting up syslog facility IDs, likely used for logging or system identification within the ngIRCd project. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | safemult_sizet | safemult_sizet | 34 | 44 |  |  |  | static bool safemult_sizet(size_t a, size_t b, size_t *res)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_init | array_init | 47 | 54 |  |  |  | void array_init(array *a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_alloc | array_alloc | 58 | 87 |  |  |  | void * array_alloc(array * a, size_t size, size_t pos)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_copy | array_copy | 106 | 114 |  |  |  | bool array_copy(array * dest, const array * const src)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_copyb | array_copyb | 118 | 129 |  |  |  | bool array_copyb(array * dest, const char *src, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_copys | array_copys | 133 | 137 |  |  |  | bool array_copys(array * dest, const char *src)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_catb | array_catb | 142 | 179 |  |  |  | bool array_catb(array * dest, const char *src, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cats | array_cats | 183 | 187 |  |  |  | bool array_cats(array * dest, const char *src)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cat0 | array_cat0 | 191 | 195 |  |  |  | bool array_cat0(array * a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cat0_temporary | array_cat0_temporary | 199 | 208 |  |  |  | bool array_cat0_temporary(array * a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_cat | array_cat | 211 | 218 |  |  |  | bool array_cat(array * dest, const array * const src)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_get | array_get | 224 | 244 |  |  |  | void * array_get(array * a, size_t membersize, size_t pos)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_free | array_free | 247 | 260 |  |  |  | void array_free(array * a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_free_wipe | array_free_wipe | 262 | 269 |  |  |  | void array_free_wipe(array *a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_trunc | array_trunc | 279 | 284 |  |  |  | void array_trunc(array * a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_truncate | array_truncate | 287 | 297 |  |  |  | void array_truncate(array * a, size_t membersize, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\array.c | function | array_moveleft | array_moveleft | 301 | 329 |  |  |  | void array_moveleft(array * a, size_t membersize, size_t pos)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\client.c | function | Client_DebugDump | Client_DebugDump | 1696 | 1711 |  |  |  | GLOBAL void Client_DebugDump(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | CheckFileReadable | CheckFileReadable | 166 | 180 |  |  |  | static void CheckFileReadable(const char *Var, const char *Filename)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conf.c | function | strdup_warn | strdup_warn | 190 | 198 |  |  |  | static char * strdup_warn(const char *str)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.c | function | Conn_DebugDump | Conn_DebugDump | 2754 | 2771 |  |  |  | GLOBAL void Conn_DebugDump(void)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\hash.c | function | Hash | Hash | 35 | 43 |  |  |  | GLOBAL UINT32 Hash( const char *String )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\hash.c | function | jenkins_hash | jenkins_hash | 84 | 138 |  |  |  | static UINT32 jenkins_hash(UINT8 *k, UINT32 length, UINT32 initval)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | field | callback | callback | 36 | 36 |  | void | scalar_or_unknown | void (*callback)(int, short);
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | field | callback | callback | 38 | 38 |  | void | scalar_or_unknown | void (*callback)();
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_debug | io_debug | 148 | 152 |  |  |  | static void io_debug(const char *s, int fd, int what)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\io.c | function | io_debug | io_debug | 154 | 156 |  |  |  | static inline void io_debug(const char UNUSED *s,int UNUSED a, int UNUSED b)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-cap.c | function | Get_CAP_String | Get_CAP_String | 98 | 109 |  |  |  | static char * Get_CAP_String(int Capabilities)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | t_diff | t_diff | 46 | 56 |  |  |  | static unsigned int t_diff(time_t *t, const time_t d)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | uptime_hrs | uptime_hrs | 64 | 68 |  |  |  | static unsigned int uptime_hrs(time_t *now)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\irc-info.c | function | uptime_mins | uptime_mins | 70 | 74 |  |  |  | static unsigned int uptime_mins(time_t *now)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_GetReason | Lists_GetReason | 58 | 63 |  |  |  | GLOBAL const char * Lists_GetReason(const struct list_elem *e)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\lists.c | function | Lists_MakeMask | Lists_MakeMask | 276 | 308 |  |  |  | GLOBAL void Lists_MakeMask(const char *Pattern, char *mask, size_t len)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\match.c | function | MatchCaseInsensitive | MatchCaseInsensitive | 66 | 75 |  |  |  | GLOBAL bool MatchCaseInsensitive(const char *Pattern, const char *String)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\ngircd.c | function | Show_Help | Show_Help | 470 | 486 |  |  |  | static void Show_Help( void )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | Get_Error | Get_Error | 111 | 126 |  |  |  | static char * Get_Error( int H_Error )
C:\develop\SpecBuilder\ngircd-master\src\ngircd\resolve.c | function | ArrayWrite | ArrayWrite | 344 | 355 |  |  |  | static void ArrayWrite(int fd, const array *a)
C:\develop\SpecBuilder\ngircd-master\src\ngircd\sighandlers.c | function | Rehash | Rehash | 101 | 151 |  |  |  | static void Rehash(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | writeblanks | writeblanks | 448 | 457 |  |  |  | int writeblanks(start, end) char *start; char *end;
C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | test1 | test1 | 472 | 551 |  |  |  | int test1(buf) char *buf;
C:\develop\SpecBuilder\ngircd-master\src\portab\ansi2knr.c | function | convert1 | convert1 | 554 | 738 |  |  |  | int convert1(buf, out, header, convert_varargs) char *buf; FILE *out; int header; /* Boolean */ int convert_varargs; /* Boolean */
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | POINTER | POINTER | 70 | 70 |  |  |  | typedef void POINTER;
C:\develop\SpecBuilder\ngircd-master\src\portab\portab.h | typedef | socklen_t | socklen_t | 134 | 134 |  |  |  | typedef int socklen_t;
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_snprintf | Check_snprintf | 34 | 44 |  |  |  | static void Check_snprintf(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strdup | Check_strdup | 46 | 59 |  |  |  | static void Check_strdup(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strndup | Check_strndup | 61 | 74 |  |  |  | static void Check_strndup(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strlcpy | Check_strlcpy | 76 | 87 |  |  |  | static void Check_strlcpy(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strlcat | Check_strlcat | 89 | 102 |  |  |  | static void Check_strlcat(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_strtok_r | Check_strtok_r | 104 | 129 |  |  |  | static void Check_strtok_r(void)
C:\develop\SpecBuilder\ngircd-master\src\portab\portabtest.c | function | Check_vsnprintf | Check_vsnprintf | 135 | 177 |  |  |  | static void Check_vsnprintf(Len, Format, va_alist) const int Len; const char *Format; va_dcl #endif
C:\develop\SpecBuilder\ngircd-master\src\portab\strdup.c | function | strdup | strdup | 18 | 32 |  |  |  | GLOBAL char * strdup(const char *s)
C:\develop\SpecBuilder\ngircd-master\src\portab\strlcpy.c | function | strlcat | strlcat | 30 | 47 |  |  |  | GLOBAL size_t strlcat( char *dst, const char *src, size_t size )
C:\develop\SpecBuilder\ngircd-master\src\portab\strlcpy.c | function | strlcpy | strlcpy | 53 | 68 |  |  |  | GLOBAL size_t strlcpy( char *dst, const char *src, size_t size )
C:\develop\SpecBuilder\ngircd-master\src\portab\strndup.c | function | strndup | strndup | 18 | 32 |  |  |  | GLOBAL char * strndup(const char *s, size_t maxlen)
C:\develop\SpecBuilder\ngircd-master\src\portab\strtok_r.c | function | strtok_r | strtok_r | 16 | 34 |  |  |  | char * strtok_r(char *str, const char *delim, char **saveptr)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | void | void | 95 | 95 |  |  |  | PARAMS(( void ))
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | dopr | dopr | 155 | 411 |  |  |  | static size_t dopr(char *buffer, size_t maxlen, const char *format, va_list args)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | fmtstr | fmtstr | 413 | 448 |  |  |  | static void fmtstr(char *buffer, size_t *currlen, size_t maxlen, char *value, int flags, int min, int max)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | fmtint | fmtint | 452 | 535 |  |  |  | static void fmtint(char *buffer, size_t *currlen, size_t maxlen, long value, int base, int min, int max, int flags)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | abs_val | abs_val | 537 | 546 |  |  |  | static LDOUBLE abs_val(LDOUBLE value)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | POW10 | POW10 | 548 | 559 |  |  |  | static LDOUBLE POW10(int exp)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | ROUND | ROUND | 561 | 571 |  |  |  | static LLONG ROUND(LDOUBLE value)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | my_modf | my_modf | 575 | 607 |  |  |  | static double my_modf(double x0, double *iptr)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | fmtfp | fmtfp | 610 | 755 |  |  |  | static void fmtfp (char *buffer, size_t *currlen, size_t maxlen, LDOUBLE fvalue, int min, int max, int flags)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | dopr_outch | dopr_outch | 757 | 764 |  |  |  | static void dopr_outch(char *buffer, size_t *currlen, size_t maxlen, char c)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | vsnprintf | vsnprintf | 767 | 771 |  |  |  | int vsnprintf (char *str, size_t count, const char *fmt, va_list args)
C:\develop\SpecBuilder\ngircd-master\src\portab\vsnprintf.c | function | snprintf | snprintf | 779 | 794 |  |  |  | int snprintf(str, count, fmt, va_alist) char *str; size_t count; const char *fmt; va_dcl #endif
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_TrimStr | ngt_TrimStr | 40 | 70 |  |  |  | GLOBAL void ngt_TrimStr(char *String)
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_UpperStr | ngt_UpperStr | 76 | 89 |  |  |  | GLOBAL char * ngt_UpperStr(char *String)
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_LowerStr | ngt_LowerStr | 95 | 108 |  |  |  | GLOBAL char * ngt_LowerStr(char *String)
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_TrimLastChr | ngt_TrimLastChr | 111 | 129 |  |  |  | GLOBAL void ngt_TrimLastChr( char *String, const char Chr)
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_RandomStr | ngt_RandomStr | 135 | 158 |  |  |  | GLOBAL char * ngt_RandomStr(char *String, const size_t len)
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_SyslogFacilityName | ngt_SyslogFacilityName | 220 | 230 |  |  |  | GLOBAL const char* ngt_SyslogFacilityName(int Facility)
C:\develop\SpecBuilder\ngircd-master\src\tool\tool.c | function | ngt_SyslogFacilityID | ngt_SyslogFacilityID | 233 | 243 |  |  |  | GLOBAL int ngt_SyslogFacilityID(char *Name, int DefaultFacility)
```

## Component: Serialization / Deserialization
- Category: technical
- Assigned symbols: 6

### Symbols
| File | Kind | Name | Qualified Name | Data Type | Data Shape | Start | End | Line Description |
|---|---|---|---|---|---|---:|---:|---|
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | struct | _ZipData | _ZipData | 64 | 71 | Defines the data structure for compressed data buffers used during the transfer of compressed data streams. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | in | _ZipData::in | 66 | 66 | Handles the in-field data type, which is a z_stream, used for serializing network packet data. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | out | _ZipData::out | 67 | 67 | Handles the output of a z_stream object, which is a data structure used for compression and decompression in the ngIRCd codebase. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | wbuf | _ZipData::wbuf | 69 | 69 | Defines the storage structure and array layout for the ZipData buffer used in data serialization. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | bytes_in | _ZipData::bytes_in | 70 | 70 | Defines the data structure and field layout for serializing binary data into a Zip archive format. |
| C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | zip | _Connection::zip | 95 | 95 | Defines the data structure and type for serializing connection state into a ZIP archive format. |

### Original Rows
```text
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | struct | _ZipData | _ZipData | 64 | 71 |  |  |  | struct _ZipData { z_stream in; /* "Handle" for input stream */ z_stream out; /* "Handle" for output stream */ array rbuf; /* Read buffer (compressed) */ array wbuf; /* Write buffer (uncompressed) */ long bytes_in, bytes_out; /* Counter for statistics (uncompressed!) */ }
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | in | _ZipData::in | 66 | 66 | _ZipData | z_stream | scalar_or_unknown | z_stream in;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | out | _ZipData::out | 67 | 67 | _ZipData | z_stream | scalar_or_unknown | z_stream out;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | wbuf | _ZipData::wbuf | 69 | 69 | _ZipData | array | array_or_collection | array wbuf;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | bytes_in | _ZipData::bytes_in | 70 | 70 | _ZipData | long | scalar_or_unknown | long bytes_in, bytes_out;
C:\develop\SpecBuilder\ngircd-master\src\ngircd\conn.h | field | zip | _Connection::zip | 95 | 95 | _Connection | ZIPDATA | scalar_or_unknown | ZIPDATA zip;
```
