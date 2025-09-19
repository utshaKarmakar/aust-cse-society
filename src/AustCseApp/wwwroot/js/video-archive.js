(function () {
    const btn = document.getElementById("btn-proceed");
    const form = document.getElementById("lookup-form");
    const list = document.getElementById("courses-list");
    const modalYs = document.getElementById("modal-ys");

    async function fetchCourses(year, semester) {
        const r = await fetch(`/VideoArchive/Courses?year=${year}&semester=${semester}`);
        if (!r.ok) throw new Error("Failed to load courses");
        return await r.json();
    }

    function renderCourses(courses) {
        list.innerHTML = "";
        if (!courses.length) {
            list.innerHTML = `<div class="alert alert-warning mb-0">No video courses found for this term.</div>`;
            return;
        }

        courses.forEach(c => {
            const row = document.createElement("div");
            row.className = "list-group-item d-flex justify-content-between align-items-center";

            const left = document.createElement("div");
            left.innerHTML = `<strong>${c.code}</strong> — ${c.title}`;

            const actions = document.createElement("div");
            if (c.links && c.links.length) {
                const watch = document.createElement("a");
                watch.href = `/VideoArchive/Watch/${c.id}`;  // redirects to first YouTube link
                watch.className = "btn btn-sm btn-danger";
                watch.textContent = "Get link";
                actions.appendChild(watch);
            } else {
                actions.innerHTML = `<span class="badge bg-secondary">No link</span>`;
            }

            row.appendChild(left);
            row.appendChild(actions);
            list.appendChild(row);
        });
    }

    btn?.addEventListener("click", async () => {
        const year = form.querySelector("[name=Year]").value;
        const semester = form.querySelector("[name=Semester]").value;

        if (!year || !semester) {
            alert("Please choose Year and Semester first.");
            return;
        }

        modalYs.textContent = `Year ${year}, Semester ${semester}`;
        try {
            const courses = await fetchCourses(year, semester);
            renderCourses(courses);
            new bootstrap.Modal(document.getElementById("coursesModal")).show();
        } catch (e) {
            alert(e.message || e);
        }
    });
})();
