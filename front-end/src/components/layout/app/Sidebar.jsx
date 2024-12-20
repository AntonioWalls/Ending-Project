import React from "react";
import {
  CDBSidebar,
  CDBSidebarContent,
  CDBSidebarFooter,
  CDBSidebarHeader,
  CDBSidebarMenu,
  CDBSidebarMenuItem
} from "cdbreact";
import { NavLink } from "react-router-dom";

const Sidebar = () => {
  return (
      <CDBSidebar textColor="#fff" backgroundColor="#333">
        <CDBSidebarHeader prefix={<i className="fa fa-bars fa-large"></i>}>
          <a
            href="/"
            className="text-decoration-none"
            style={{ color: "inherit" }}
          >
            Ending App
          </a>
        </CDBSidebarHeader>

        <CDBSidebarContent className="sidebar-content">
          <CDBSidebarMenu>
            <NavLink exact to="/" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Inicio</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Inmobiliarias" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Inmobiliarias</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Remates" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Remates</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Adjudicados" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Adjudicados</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Litigiosos" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="users">Litigiosos</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Litigios" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Litigios</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Propiedades" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Propiedades</CDBSidebarMenuItem>
            </NavLink>
            <NavLink exact to="/Reportes" activeClassName="activeClicked">
              <CDBSidebarMenuItem icon="home">Reportes</CDBSidebarMenuItem>
            </NavLink>
          </CDBSidebarMenu>
        </CDBSidebarContent>

        <CDBSidebarFooter style={{ textAlign: "center" }}>
          <div
            style={{
              padding: "20px 5px"
            }}
          >
            Sistema Base © 2024
          </div>
        </CDBSidebarFooter>
      </CDBSidebar>
  );
};

export default Sidebar;
