<script>



    var wsUri = "ws://localhost:8090/Payment";
    var output;

    function init() {
        testWebSocket();
    }

    function testWebSocket() {
        websocket = new WebSocket(wsUri);
        websocket.onopen = function (evt) { onOpen(evt) };
        websocket.onclose = function (evt) { onClose(evt) };
        websocket.onmessage = function (evt) { onMessage(evt) };
        websocket.onerror = function (evt) { onError(evt) };
    }

    function onOpen(evt) {

        doSend("Message Data ...");
    }

    function onClose(evt) {
    }

    function onMessage(evt) {

    }

    function onError(evt) {
        write(evt.data);
    }

    function doSend(message) {

        websocket.send(message);
    }


    window.addEventListener("load", init, false);

</script>
