const phrases = [
    "Майбутній розробник ",
    "Люблю код і ігри ",
    "Навчаюся щодня ",
    "Хочу працювати в IT "
];

let index = 0;

function changePhrase() {
    index = (index + 1) % phrases.length;
    document.getElementById("dynamic-text").textContent = phrases[index];
}

function addSkill() {
    const input = document.getElementById("skill-input");
    const skillText = input.value.trim();

    if (skillText === "") return;

    const span = document.createElement("span");
    span.className = "skill";
    span.innerHTML = `${skillText} <button onclick="removeSkill(this)">✖</button>`;

    document.getElementById("skills-list").appendChild(span);
    input.value = "";
}

function removeSkill(button) {
    button.parentElement.remove();
}
