(function () {
    const btn = document.getElementById("btn-proceed");
    const form = document.getElementById("lookup-form");
    const list = document.getElementById("courses-list");
    const loading = document.getElementById("loading");
    const modalYs = document.getElementById("modal-ys");
    const ysPreview = document.getElementById("ys-preview");

    function getFormValues() {
        return {
            studentId: form.querySelector("[name=StudentId]").value.trim(),
            year: form.querySelector("[name=Year]").value,
            semester: form.querySelector("[name=Semester]").value
        };
    }

    async function fetchCourses(year, semester) {
        const r = await fetch(`/StudyMaterials/Courses?year=${year}&semester=${semester}`, {
            headers: { "Accept": "application/json" }
        });
        if (!r.ok) throw new Error("Failed to load courses");
        return await r.json();
    }

    function showLoading(isLoading) {
        loading.classList.toggle("d-none", !isLoading);
        list.classList.toggle("d-none", isLoading);
    }

    function courseRow(c) {
        return `
    <div class="list-group-item d-flex flex-column flex-md-row justify-content-between align-items-md-center">
      <div class="mb-2 mb-md-0">
        <span class="badge bg-light text-dark border me-2">${c.code}</span>
        <span class="fw-semibold">${c.title}</span>
      </div>
      <div>
        <a class="btn btn-primary btn-sm" href="/StudyMaterials/Go/${c.id}">
          Get link
        </a>
      </div>
    </div>`;
    }


    function renderCourses(courses) {
        list.innerHTML = "";
        if (!courses.length) {
            list.innerHTML = `<div class="alert alert-warning m-0">No courses found for this term.</div>`;
            return;
        }
        list.innerHTML = courses.map(courseRow).join("");
    }

    btn?.addEventListener("click", async () => {
        const { studentId, year, semester } = getFormValues();

        // simple validation
        if (!studentId) {
            alert("Please enter your Student ID.");
            form.querySelector("[name=StudentId]").focus();
            return;
        }

        modalYs.textContent = `Year ${year}, Semester ${semester}`;
        ysPreview.textContent = `Showing courses for Year ${year}, Semester ${semester}`;

        try {
            showLoading(true);
            const courses = await fetchCourses(year, semester);
            renderCourses(courses);
        } catch (e) {
            list.innerHTML = `<div class="alert alert-danger">Oops! ${e.message || e}</div>`;
        } finally {
            showLoading(false);
            const modal = new bootstrap.Modal(document.getElementById('coursesModal'));
            modal.show();
        }
    });

    // Allow pressing Enter to trigger Proceed
    form?.addEventListener("keydown", (e) => {
        if (e.key === "Enter") {
            e.preventDefault();
            btn.click();
        }
    });
})();
