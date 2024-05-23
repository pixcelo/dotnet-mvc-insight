const btnInsight = document.getElementById("btn-insight");
btnInsight.addEventListener("click", getInsightData);

async function getInsightData() {
    try {
        const response = await fetch("api/insight");
        const data = await response.json();
        console.log(data);
    } catch (err) {
        console.error(err);
    }
}

const btnMedia = document.getElementById("btn-media");
btnMedia.addEventListener("click", getMedia);

async function getMedia() {
    try {
        const response = await fetch("api/media");
        const result = await response.json();
        console.log(result);

        const mediaList = document.getElementById("media-list");
        mediaList.innerHTML = "";

        result.forEach((media) => {
            const listItem = document.createElement("li");
            listItem.innerHTML = `
                <img style="width: 10%;" src="${media.media_url}" alt="${media.id}" /> <span class="media-caption">${media.caption}</span>
              `;
            mediaList.appendChild(listItem);
        });

    } catch (err) {
        console.error(err);
    }
}