const btn = document.getElementById("btn-get");
btn.addEventListener("click", getData);

async function getInsightData() {
    try {
        const response = await fetch("api/insight");
        const data = await response.json();
        console.log(data);
    } catch (err) {
        console.error(err);
    }
}