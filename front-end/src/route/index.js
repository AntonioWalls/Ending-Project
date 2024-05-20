import Inicio from "../components/pages/Inicio";
import Usuarios from "../components/pages/users";
import Role from "../components/pages/Role";
import Inmobiliarias from "../components/pages/realestate";
import Remates from "../components/pages/auction";

const Routes = [
    {
        path: '/',
        component: Inicio,
    },
    {
        path: 'Usuarios',
        component: Usuarios
    },
    {
        path: 'Role',
        component: Role
    },
    {
        path: 'Inmobiliarias',
        component: Inmobiliarias
    },
    {
        path: 'Remates',
        component: Remates
    }
];
export default Routes;