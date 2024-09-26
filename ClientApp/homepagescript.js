// Function to submit customer details
async function submitCustomerDetails() {
    const name = document.getElementById('customerName').value;
    const phone = document.getElementById('customerPhone').value;
    const address = document.getElementById('customerAddress').value;
    const email = document.getElementById('customerEmail').value;
    
    if (!name || !phone || !address || !email) {
        alert('Please fill in all customer details.');
        return;
    }

    try {
        const response = await fetch(`https://localhost:7075/api/Customer/create`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name,
                phone,
                address,
                email,
            }),
        });

        if (!response.ok) {
            throw new Error('Failed to submit customer details.');
        }

        const result = await response.json();
        alert(`Customer details submitted.`);
    } catch (error) {
        console.error(error);
        alert('Error submitting customer details.');
    }
}

// Function to submit size details
async function fetchSizeDetails() {
    const customerId = document.getElementById('customerId').value;

    if (!customerId) {
        alert('Please enter a Customer ID.');
        return;
    }

    try {
        const response = await fetch(`https://localhost:7075/api/Customer`);
        if (response.ok) {
            const data = await response.json();
            populateForm(data);
            document.querySelector('.size-details').style.display = 'block'; // Show size details fields
        } else {
            alert('Customer ID not found.');
            document.querySelector('.size-details').style.display = 'none'; // Hide size details fields if ID not found
        }
    } catch (error) {
        console.error('Error fetching size details:', error);
        alert('An error occurred while fetching size details.');
    }
}

function populateForm(data) {
    document.getElementById('bottomLength').value = data.bottomLength || '';
    document.getElementById('waist').value = data.waist || '';
    document.getElementById('bottomLeg').value = data.bottomLeg || '';
    document.getElementById('topLength').value = data.topLength || '';
    document.getElementById('collar').value = data.collar || '';
    document.getElementById('chest').value = data.chest || '';
    document.getElementById('sleeve').value = data.sleeve || '';
    document.getElementById('shoulder').value = data.shoulder || '';
    document.getElementById('description').value = data.description || '';
}

async function submitSizeDetails() {
    const customerId = document.getElementById('customerId').value;
    const bottomLength = document.getElementById('bottomLength').value;
    const waist = document.getElementById('waist').value;
    const bottomLeg = document.getElementById('bottomLeg').value;
    const topLength = document.getElementById('topLength').value;
    const collar = document.getElementById('collar').value;
    const chest = document.getElementById('chest').value;
    const sleeve = document.getElementById('sleeve').value;
    const shoulder = document.getElementById('shoulder').value;
    const description = document.getElementById('description').value;

    const sizeDetails = {
        customerId: customerId,
        bottomLength: parseFloat(bottomLength),
        waist: parseFloat(waist),
        bottomLeg: parseFloat(bottomLeg),
        topLength: parseFloat(topLength),
        collar: parseFloat(collar),
        chest: parseFloat(chest),
        sleeve: parseFloat(sleeve),
        shoulder: parseFloat(shoulder),
        description: description
    };

    try {
        const response = await fetch(`https://localhost:7075/api/size/create/${customerId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(sizeDetails)
        });

        if (response.ok) {
            alert('Size details saved successfully.');
        } else {
            alert('Failed to save size details.');
        }
    } catch (error) {
        console.error('Error saving size details:', error);
        alert('An error occurred while saving size details.');
    }
}

// Function to assign an order to a tailor
async function assignOrder() {
    // Get the orderId entered by the user
    const orderId = document.getElementById("orderIdInput").value;
    
    // Clear any previous messages
    const messageDiv = document.getElementById("message");
    messageDiv.innerHTML = '';

    try {
        // Make API call to check if the order exists
        const response = await fetch(`/api/orders/${orderId}`);
        
        if (response.ok) {
            // If the response is OK (200), the order exists
            messageDiv.innerHTML = `<div class="alert alert-success">Order ${orderId} is valid. Proceeding with tailor assignment.</div>`;
            // Here, you can add the logic to assign the order to the selected tailor
        } else if (response.status === 404) {
            // If the order is not found (404)
            messageDiv.innerHTML = `<div class="alert alert-danger">Order ID ${orderId} is not valid. Please enter a valid Order ID.</div>`;
        } else {
            // Handle other possible response statuses
            messageDiv.innerHTML = `<div class="alert alert-danger">An error occurred while checking the Order ID. Please try again later.</div>`;
        }
    } catch (error) {
        // Handle any network errors or unexpected issues
        messageDiv.innerHTML = `<div class="alert alert-danger">An error occurred: ${error.message}</div>`;
    }
}

async function fetchTailors() {
    try {
        const response = await fetch('https://localhost:7075/api/Tailor'); // Replace with your API endpoint
        const tailors = await response.json();

        const selectElement = document.getElementById('assignTailor');
        selectElement.innerHTML = ''; // Clear existing options

        // Populate the select dropdown with the fetched tailors
        tailors.forEach(tailor => {
            const option = document.createElement('option');
            option.value = tailor.id; // Assuming tailor has an 'id' property
            option.text = tailor.name; // Assuming tailor has a 'name' property
            selectElement.add(option);
            console.log("ops::",tailors,option);

        });
    } catch (error) {
        console.error('Error fetching tailors:', error);
    }
}

// Assign order to the selected tailor
async function assignOrder() {
    const tailorId = document.getElementById('assignTailor').value;
    const orderId =0 /* Get order ID from context or user input */;

    try {
        const response = await fetch(`https://localhost:7075/api/Order/assignOrder`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ orderId, tailorId })
        });

        if (response.ok) {
            alert('Order successfully assigned!');
        } else {
            alert('Failed to assign order.');
        }
    } catch (error) {
        console.error('Error assigning order:', error);
    }
}

// Call the fetchTailors function when the page loads
document.addEventListener('DOMContentLoaded', fetchTailors);


// Function to update the order status
async function updateOrderStatus() {
    const orderId = document.getElementById("orderId").value;
    const orderStatus = document.getElementById("orderStatus").value;
    
    if (!orderId) {
        document.getElementById("statusMessage").innerHTML = "<p style='color: red;'>Please enter a valid Order ID.</p>";
        return;
    }
    
    try {
        const response = await fetch('https://localhost:7075/api/Order/updatestatus', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                orderId: orderId,
                status: orderStatus
            })
        });
        
        const result = await response.json();

        if (response.ok) {
            document.getElementById("statusMessage").innerHTML = "<p style='color: green;'>Order status updated successfully!</p>";
        } else {
            document.getElementById("statusMessage").innerHTML = `<p style='color: red;'>Error: ${result.message}</p>`;
        }
    } catch (error) {
        document.getElementById("statusMessage").innerHTML = "<p style='color: red;'>An error occurred while updating the order status.</p>";
    }
}
function getOption() {
    selectElement =
        document.querySelector('#orderStatus');
    output =
        selectElement.options
        [selectElement.selectedIndex].value;
        console.log("out::",output);
    document.querySelector('.output').textContent = output;
}
// window.onload = async function() {
//     const response = await fetch('https://localhost:7075/api/Order/statuslist');
//     const statuses = await response.json();
    
//     const orderStatusDropdown = document.getElementById("orderStatus");
//     statuses.forEach(status => {
//         let option = document.createElement("option");
//         option.value = status.Id;
//         option.text = status.Name;
//         orderStatusDropdown.appendChild(option);
//     });
// }