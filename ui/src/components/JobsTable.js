import { useState, useEffect } from "react";

const JobsTable = () => {
  const [jobs, setJobs] = useState([]);

  useEffect(() => {
    requestJobs();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  async function requestJobs() {
    const res = await fetch(`./download-jobs.json`);
    const json = await res.json();
    setJobs(json.map((x) => x.records.postings).flat());
    console.log(json.map((x) => x.records.postings).flat());
  }
  if (jobs.length == 0) {
    return <div>nothing to render</div>;
  }
  return (
    <div className="jobs-table">
      <table>
        <thead>
          <tr>
            <td>link</td>
            <td>status</td>
            <td>description</td>
          </tr>
        </thead>
        <tbody>
          {jobs.map((job) => {
            return (
              <tr key={job.id}>
                <td>
                  <a href={`https://jobs.netflix.com/jobs/${job.external_id}`}>
                    {job.text}
                  </a>
                </td>
                <td>{job.Status}</td>
                <td dangerouslySetInnerHTML={{ __html: job.description }}></td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};

export default JobsTable;
