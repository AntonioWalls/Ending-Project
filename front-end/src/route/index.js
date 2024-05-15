import Inicio from "../components/pages/Inicio";
import Usuarios from "../components/pages/users";
import Role from "../components/pages/Role";
import Inmobiliarias from "../components/pages/realestate";

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
    }
];
export default Routes;