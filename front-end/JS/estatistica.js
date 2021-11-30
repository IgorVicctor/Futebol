function fazPost(url, body) {
    console.log("Body=", body)
    let request = new XMLHttpRequest()
    request.open("POST", url, true)
    request.setRequestHeader("Content-type", "application/json; charset=UTF-8")
    request.send(JSON.stringify(body))

    request.onload = function() {
        console.log(this.responseText)
    }

    return request.responseText
}

function adicionar() {
    event.preventDefault()
    let url = "https://localhost:5001/futebol/arbitragens"
    let gols = document.getElementById("gols").value
    let impedimentos = document.getElementById("impedimentos").value
    let faltas = document.getElementById("faltas").value
    let cartaoamarelo = document.getElementById("cartaoamarelo").value
    let cartaovermelho = document.getElementById("cartaovermelho").value

    body = {
        "numGols": gols,
        "numCartAm": cartaoamarelo,
        "numCartVer": cartaovermelho,
        "numFaltas": faltas,
        "numImpedimentos": impedimentos,
    }

        fazPost(url, body)

        alert('As estatísticas foram adicionadas!')
    }

