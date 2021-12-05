var web3;

if (window.ethereum) {
    web3 = new Web3(window.ethereum);

    fetch('./GameSaloon.json')
        .then(res => res.json())
        .then(res => {
            GameSaloon = res;
            gameSaloon = new web3.eth.Contract(
                    GameSaloon.abi,
                    GameSaloon.address
                )
                // connect popup
            ethereum.enable();

            window.ethereum.on("accountsChanged", function() {
                location.reload();
            });
        })


}
