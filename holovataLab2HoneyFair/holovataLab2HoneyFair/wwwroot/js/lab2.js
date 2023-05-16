const uri = 'api/FairLocations';
let fairLocations = [];

function getFairLocations() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFairLocations(data))
        .catch(error => console.error('Unable to get fair locations.', error));
}

function addFairLocation() {
    const addCityTextbox = document.getElementById('add-city');
    const addAddressTextbox = document.getElementById('add-address');

    const fairLocation = {
        city: addCityTextbox.value.trim(),
        address: addAddressTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(fairLocation)
    })
        .then(response => response.json())
        .then(() => {
            getFairLocations();
            addCityTextbox.value = '';
            addAddressTextbox.value = '';
        })
        .catch(error => console.error('Unable to add fair location.', error));
}

function deleteFairLocation(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFairLocations())
        .catch(error => console.error('Unable to delete fair location.', error));
}

function displayEditForm(id) {
    const fairLocation = fairLocations.find(fairLocation => fairLocation.id === id);

    document.getElementById('edit-id').value = fairLocation.id;
    document.getElementById('edit-city').value = fairLocation.city;
    document.getElementById('edit-address').value = fairLocation.address;
    document.getElementById('editForm').style.display = 'block';
}

function updateFairLocation() {
    const fairLocationId = document.getElementById('edit-id').value;
    const fairLocation = {
        id: parseInt(fairLocationId, 10),
        city: document.getElementById('edit-city').value.trim(),
        address: document.getElementById('edit-address').value.trim()
    };
    fetch(`${uri}/${fairLocationId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(fairLocation)
    })
        .then(() => getFairLocations())
        .catch(error => console.error('Unable to update fair location.', error));
    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayFairLocations(data) {
    const tBody = document.getElementById('fairLocations');

    tBody.innerHTML = '';
    const button = document.createElement('button');
    data.forEach(fairLocation => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${fairLocation.id})`);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFairLocation(${fairLocation.id})`);
        let tr = tBody.insertRow();
        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(fairLocation.city);
        td1.appendChild(textNode);
        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(fairLocation.address);
        td2.appendChild(textNodeInfo);
        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);
        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });
    fairLocations = data;
}