# O que é o serviço Firebase Cloud Messaging (FCM) ?

O Firebase Cloud Messaging (FCM) é uma solução de mensagens que permite a entrega de mensagens e notificações. 
O FCM é a nova versão do GCM que herda sua infra-estrutura confiável e escalável, além de agregar novos!

Para conhecer mais sobre o Firebase Cloud Messaging acesse o link abaixo:

* [Firebase Cloud Messaging (FCM)](http://firebase.google.com)

Qual a utilidade da biblioteca FirebaseCloudMessaging?
-----------------------------------------------------

O biblioteca `FirebaseCloudMessaging` tem como objetivo facilitar o envio dessas mensagem utilizando o serviço do FCM.
Usando o FCM, é possível enviar notificações para o aplicativo cliente, seja ele `Android`, `iOS` ou `Web`. Porém, é necessário que sua aplicação possua suporte a receber notificações e que você possua o `DeviceId` para envio.

Como utilizar?
-------------

Em seu projeto que irá fazer o envio das notificações, faça referência a bibilioteca `Firebase Cloud Messaging` 

```
var SERVER_API_KEY = "<server_api_key>";
var SENDER_ID = "sender_id";

using (var fcm = new FCM(SERVER_API_KEY, SENDER_ID))
{
  var notification = new FCMPushNotification() { 
    DeviceId = "<device_id>" 
  };
		
  var result = fcm.SendNotification(notification);
  Console.WriteLine(result);
};

```

Para dúvidas, podem entrar em [contato comigo](http://raphaelcardoso.com.br/)

