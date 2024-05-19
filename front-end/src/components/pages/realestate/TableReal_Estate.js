import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { getRealState } from '../../../redux/actions/ActionReal_State';


export default function TableReal_Estate({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { realstates } = useSelector((state) => state.getRealState);


  // Obtener la id del usuario. 
  const [id, setId] = useState(0);
  const gridRef = useRef();
  const onSelectionChanged = useCallback(() => {
    const selectedRows = gridRef.current.api.getSelectedRows();
    document.querySelector("#selectedRows").innerHTML =
      selectedRows.length === 1 ? selectedRows[0].nombre : "";
    console.log(selectedRows[0].idUsuario);
    setId(selectedRows[0].idUsuario);
    console.log(id)

  }, []);



  useEffect(() => {
    dispatch(getRealState());
    console.log(realstates);
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idInmobiliaria', headerName: 'ID' },
    { field: 'razonSocial', headerName: 'Nombre' },
    { field: 'rfc', headerName: 'Primer Apellido' },
    { field: 'telefono', headerName: 'Segundo Apellido' }
  ]);


  const handleNew = () => {
    showForm();
    idUserEdit(0);
  };

  const handleEdit = () => {
    console.log(realstates)
    // if (id) {
    //   idUserEdit(id);
    //   showForm();
    // } else {
    //   alert('Seleccione un usuario para modificar');
    // }
  };

  // const handleEdit = () => {
  //     console.log(id);
  //     if(id){
  //         showForm();
  //     }else{
  //         alert('Seleccione un usuario para modificar');
  //     }
  // };

  const handleDelete = () => {
    // console.log(id);
    // if (id) {
    //   // Eliminar usuario seleccionado
    //   dispatch(deleteUser(id))
    //     .then(() => {
    //       window.location.href = window.location.href;
    //     })
    // } else {
    //   alert("Seleccione un usuario para eliminar");
    // }
  };


  // ...

  return (

    // wrapping container with theme & size
    <div
      className="ag-theme-quartz" // applying the grid theme
      style={{ height: 500 }} // the grid will fill the size of the parent container
    >
      <Row >
        <Col>
          <Button variant='primary' onClick={handleNew}>Nuevo Usuario</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Usuario</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Usuario</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Usuario seleccionado: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      {realstates ? console.log(realstates) : null}
    </div>
  )

}