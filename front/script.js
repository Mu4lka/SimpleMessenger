const url = "http://localhost:8080"

function appendMessage(message) {
    const messageElement = document.createElement("div");
    messageElement.classList.add("message");
    
    const timestamp = new Date(message.createdDate).toLocaleString();

    messageElement.innerHTML = `
        <div class="message-header">
            <span class="message-sequence">${message.sequenceNumber}</span>
            <span class="message-timestamp">${timestamp}</span>
        </div>
        <div class="message-content">${message.content}</div>
    `;

    messagesContainer.appendChild(messageElement);
    messagesContainer.scrollTop = messagesContainer.scrollHeight;
}

async function fetchMessages() {
    const now = new Date();
    const startDate = new Date(now.getTime() - 10 * 60000).toISOString();
    const endDate = now.toISOString();
    
    const response = await fetch(`${url}/api/messages?startDate=${startDate}&endDate=${endDate}`);

    if (response.ok) {
        const getMessagesRequest = await response.json();
        const messages = getMessagesRequest.messages;
        messages.forEach(appendMessage);
    }
}

const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${url}/messageHub`)
    .build();

connection.start()
    .then(() => {
        console.log("SignalR Connected.");
        
        fetchMessages();

        connection.on("receiveMessage", appendMessage);
    })
    .catch(err => console.error("SignalR Connection Error: ", err));

const messageInput = document.getElementById('messageInput');
const sendMessageButton = document.getElementById('sendMessageButton')
const messagesContainer = document.getElementById('messagesContainer');

sendMessageButton.addEventListener('click', async () => {
    const messageContent = messageInput.value;

    if (!messageContent.trim())
        return;

    const lastMessageElement = messagesContainer.lastElementChild;
    let lastSequenceNumber = 0;

    if (lastMessageElement) {
        const lastMessageText = lastMessageElement.innerText;
        const lastSequenceNumberText = lastMessageText.split('\n')[0].trim();
        lastSequenceNumber = parseInt(lastSequenceNumberText, 10);
    }

    const sequenceNumber = lastSequenceNumber + 1;

    await fetch(`${url}/api/messages`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            content: messageContent,
            sequenceNumber: sequenceNumber
        })
    });
    messageInput.value = '';             
});