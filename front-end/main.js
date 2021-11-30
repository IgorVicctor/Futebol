/*fetch('https://localhost:5001/futebol/arbitragens/1')
    .then((response) => response.json())
    .then(function (data) {
        let authors = data;
        console.log(authors);
        return authors.map(function (author) {

            let h = document.createElement('h3');

            h.innerHTML = author.numGols;

            var ul = document.getElementById('authors');
            let li = document.createElement('li');
            
            li.appendChild(h);

            ul.appendChild(li);
        })
    })
    .catch(function (error) {
        console.log(error);
    });*/


/*const carregarProdutos = async () => {
    const response = await fetch(`https://localhost:5001/futebol/arbitragens`)
    const dados = await response.json()
    console.log(dados)

    dados.forEach(item => {
        const containerProdutoElement = document.getElementById('container-produtos')

        const template = document.getElementById("produto-template")

        const produtoElement = document.importNode(template.content, true)

        const itens_produto = produtoElement.querySelectorAll('span')

        itens_produto[0].innerText = item.numGols
        itens_produto[1].innerText = item.numCartAm
        itens_produto[2].innerText = item.numCartVer
        itens_produto[3].innerText = item.numFaltas
        itens_produto[4].innerText = item.numImpedimentos

        containerProdutoElement.append(produtoElement)
    })
}

window.onload = () =>{
    carregarProdutos()

}*/