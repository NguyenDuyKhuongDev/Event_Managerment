$(() => {
    LoadEventData(); // Gọi dữ liệu khi trang load

    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/signalrServer") // Địa chỉ Hub SignalR
        .build();

    connection.start().then(() => {
        console.log("SignalR connected successfully!");
    }).catch((err) => {
        console.error("SignalR connection failed: ", err.toString());
    });

    // Lắng nghe sự kiện "LoadEvents" từ server để cập nhật danh sách sự kiện
    connection.on("LoadEvents", function () {
        console.log("Received update from server, reloading event data...");
        LoadEventData();
    });

    // Hàm load danh sách sự kiện
    function LoadEventData() {
        $.ajax({
            url: '/Events/GetEvents', // API trả về danh sách sự kiện dạng JSON
            method: 'GET',
            dataType: 'json',
            success: function (response) {
                console.log("Response from server:", response);
                var tr = '';
                $.each(response, function (index, event) {
                    tr += `<tr>
                        <td>${event.title}</td>
                        <td>${event.description}</td>
                        <td>${event.startTime}</td>
                        <td>${event.endTime}</td>
                        <td>${event.location}</td>
                       <td>${event.categoryName}</td>

                        <td>
                            <a href='/Events/Edit/${event.eventID}'>Edit</a> |
                            <a href='/Events/Details/${event.eventID}'>Details</a> |
                            <a href='/Events/Delete/${event.eventID}'>Delete</a>
                        </td>
                    </tr>`;
                });
                $("#EventTable").html(tr);
            },
            error: function (error) {
                console.log("Error loading events:", error);
            }
        });
    }
});