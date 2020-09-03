import React, { Component } from 'react';

export class FetchLoai extends Component {
  static displayName = FetchLoai.name;

  constructor(props) {
    super(props);
    this.state = { categories: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(categories) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Mã Loại</th>
            <th>Tên Loại</th>
            <th>Mô Tả</th>
            <th>Hình</th>
          </tr>
        </thead>
        <tbody>
          {categories.map(loai =>
              <tr key={loai.maLoai}>
                  <td>{loai.maLoai}</td>
              <td>{loai.tenLoai}</td>
              <td>{loai.moTa}</td>
              <td>{loai.hinh}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchLoai.renderForecastsTable(this.state.categories);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('api/loai');
    const data = await response.json();
    this.setState({ categories: data, loading: false });
  }
}
