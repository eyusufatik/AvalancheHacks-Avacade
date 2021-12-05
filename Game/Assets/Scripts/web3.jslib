// web3.jslib

mergeInto(LibraryManager.library, {
    WalletAddress: function() {
        var returnStr;
        try {
            // get address from metamask
            returnStr = web3.currentProvider.selectedAddress;
        } catch (e) {
            returnStr = "";
        }
        var returnStr = web3.currentProvider.selectedAddress;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    MintGame: async function(tokenURI) {
        var buffer;
        var address = web3.currentProvider.selectedAddress;
        var returnValues;
        var mintFee = await gameSaloon.methods.mintFee().call();
        console.log(tokenURI)
        tokenURI = Pointer_stringify(tokenURI);
        console.log(tokenURI);
        var transaction = await gameSaloon.methods
            .mintGame(tokenURI.toString(), address)
            .send({ from: address, value: mintFee.toString() });

        returnValues = transaction.events.Minted.returnValues;
        console.log(returnValues.tokenId);
        var bufferSize = lengthBytesUTF8(transaction.blockHash) + 1;
        buffer = _malloc(bufferSize);
        stringToUTF8(transaction.blockHash, buffer, bufferSize);
        // very shitty hack but we gotta make haste
        myInstance.SendMessage("web3mng", "GetMintReturn", returnValues.tokenId + "~" + returnValues.tokenAddress);
        return buffer;
    },
    RentPlace: async function(placeId, gameId) {
        var address = web3.currentProvider.selectedAddress;
        var rent = await gameSaloon.methods
            .placeRent(placeId).call();
        var transaction = await gameSaloon.methods
            .rentPlace(placeId, gameId, address)
            .send({ from: address, value: rent.toString() });
        returnValue = transaction.events.Rented.returnValues;
        var gameId = returnValue.place.gameId;
        var ownerAddress = returnValue.place.ownerAddress;
        var placeId = returnValue.placeId;
        myInstance.SendMessage("web3mng", "GetRentPlaceReturn", placeId + "~" + gameId + "~" + ownerAddress);
        console.log(returnValue);
    },
    BuyToken: async function(tokenAmount) {
        var address = web3.currentProvider.selectedAddress;
        var latestPrice = await gameSaloon.methods.getLatestPrice().call();
        var transaction = await gameSaloon.methods
            .buyToken(tokenAmount)
            .send({ from: address, value: (Math.pow(10, 18) * (tokenAmount * Math.pow(10, 8) * 1 / latestPrice)).toString() });
        returnValue = transaction.events.TokenBuyed.returnValues;
        myInstance.SendMessage("web3mng", "GetBuyTokenReturn", "");
        console.log(returnValue);
    },

    CheckTokenAmount: async function() {
        var address = web3.currentProvider.selectedAddress;
        var tokenAmount = await gameSaloon.methods.getUserBalance(address).call();

        myInstance.SendMessage("web3mng", "GetCheckTokenAmountReturn", tokenAmount.toString());
    },
    PlayGame: async function(placeId) {
        var address = web3.currentProvider.selectedAddress;

        await gameSaloon.methods.playGame(placeId).send({ from: address });

        myInstance.SendMessage("web3mng", "GetPlayGameReturn", "true");
    },
    GetGameURI: async function(gameId) {
        var gameURI = await gameSaloon.methods.getGameURI(gameId).call();

        myInstance.SendMessage("web3mng", "GetGameURIReturn", gameId + "~" + gameURI);
    },
    OpenTab: function(url) {
        url = UTF8ToString(url);
        sp = url.split("/");
        url = sp[0] + "/" + sp[1] + "/" + sp[2] + "/";
        window.open(url, '_blank').focus();
        console.log(url);
    },
    CheckPlace: async function(placeId) {
        var obj = await gameSaloon.methods.place(placeId).call();
        myInstance.SendMessage("web3mng", "GetCheckPlaceReturn", placeId + "~" + obj.isFull.toString() + "~" + obj.gameId);

    }
});