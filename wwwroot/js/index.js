document.getElementById("registrationForm").addEventListener("submit", async function(e) {
                e.preventDefault();

                const data = {
                    lastName: document.getElementById("lastName").value,
                    hisName: document.getElementById("hisName").value,
                    herName: document.getElementById("herName").value,
                    hisPhone: document.getElementById("hisPhone").value,
                    herPhone: document.getElementById("herPhone").value,
                    city: document.getElementById("city").value,
                    readSpanish: document.getElementById("readSpanish").checked ? "Si" : "No",
                    zone: Number(document.getElementById("zone").value || 0),
                    churchMarried: document.getElementById("churchMarried").checked ? "Si" : "No",
                    yearsMarried: Number(document.getElementById("years").value || 0),
                    paid: Number(document.getElementById("paid").value || 0),
                    comments: document.getElementById("comments").value

                };

                try{
                    const response = await fetch("/api/registrations", {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(data)
                    });

                    const message = document.getElementById("message");

                    if(response.ok)
                    {
                        message.textContent = "Registration Successful";
                        message.className = "success";
                        document.getElementById("registrationForm").reset();
                    }
                    else
                    {
                        message.textContent = "Error Submitting Form";
                        message.className = "error";
                    }
                }
                catch(error)
                {
                    document.getElementById("message").textContent = "Server Error";
                }
            });