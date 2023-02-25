import { FetchData } from "./components/Transactions/FetchData";

const AppRoutes = [
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    index: true,
    path: '/',
    element: <FetchData />
  }
];

export default AppRoutes;
