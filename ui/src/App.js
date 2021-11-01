import { StrictMode } from "react";
import { render } from "react-dom";
import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";
import JobsTable from "./components/JobsTable";

const App = () => {
  return (
    <div>
      <Router>
        <header>
          <Link to="/">Netflix Senior Software Engineer Jobs</Link>
        </header>
        <Switch>
          <Route path="/">
            <JobsTable />
          </Route>
        </Switch>
      </Router>
    </div>
  );
};

render(
  <StrictMode>
    <App />
  </StrictMode>,
  document.getElementById("root")
);
