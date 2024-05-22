import Inicio from "../components/pages/Inicio";
import Usuarios from "../components/pages/users";
import Role from "../components/pages/Role";
import Inmobiliarias from "../components/pages/realestate";
import Remates from "../components/pages/auction";
import Adjudicados from "../components/pages/awarded";
import Litigiosos from "../components/pages/litigious";
import Litigios from "../components/pages/litigation";

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
    },
    {
        path: 'Adjudicados',
        component: Adjudicados
    },
    {
        path: 'Litigiosos',
        component: Litigiosos
    },
    {
        path: 'Litigios',
        component: Litigios
    }
];
export default Routes;