function getStream() {
    return new Uint8Array(10_000_000);
}

async function setStream(streamRef) {
    const data = await streamRef.arrayBuffer();    // ArrayBuffer
    // or
    const stream = await streamRef.stream();       // ReadableStream
}

function render() {
    let containerElement = document.getElementById('counter');
    await Blazor.rootComponents.add(containerElement, 'counter', { incrementAmount: 10 });
}